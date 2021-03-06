﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Bloom.Book;
using Bloom.Collection;
using Bloom.CollectionTab;
using Bloom.Edit;
using Bloom.ImageProcessing;
using Bloom.Library;
using Bloom.Properties;
using Bloom.SendReceive;
using Bloom.Workspace;
using Bloom.web;
using Chorus;
using Palaso.Extensions;
using Palaso.IO;
using Palaso.Reporting;

namespace Bloom
{
	public class ProjectContext : IDisposable
	{
		/// <summary>
		/// Any resources which belong only to this project will be tracked by this,
		/// and disposed of along with this ProjectContext class
		/// </summary>
		private ILifetimeScope _scope;

		private BloomServer _bloomServer;
		private ImageServer _imageServer;
		public Form ProjectWindow { get; private set; }

		public ProjectContext(string projectSettingsPath, IContainer parentContainer)
		{
			BuildSubContainerForThisProject(projectSettingsPath, parentContainer);

			ProjectWindow = _scope.Resolve <Shell>();

			string collectionDirectory = Path.GetDirectoryName(projectSettingsPath);

			//should we save a link to this in the list of collections?
			var collectionSettings = _scope.Resolve<CollectionSettings>();
			if(collectionSettings.IsSourceCollection)
			{
				AddShortCutInComputersBloomCollections(collectionDirectory);
			}

			if(Path.GetFileNameWithoutExtension(projectSettingsPath).ToLower().Contains("web"))
			{
				BookCollection editableCollection = _scope.Resolve<BookCollection.Factory>()(collectionDirectory, BookCollection.CollectionType.TheOneEditableCollection);
				var sourceCollectionsList = _scope.Resolve<SourceCollectionsList>();
				_bloomServer = new BloomServer(_scope.Resolve<CollectionSettings>(), editableCollection, sourceCollectionsList, _scope.Resolve<HtmlThumbNailer>());
				_bloomServer.Start();
			}
			else
			{
				if (Settings.Default.ImageHandler != "off")
				{
					_imageServer = _scope.Resolve<ImageServer>();

					_imageServer.StartWithSetupIfNeeded();
				}
			}
		}

		/// ------------------------------------------------------------------------------------
		protected void BuildSubContainerForThisProject(string projectSettingsPath, IContainer parentContainer)
		{
			var editableCollectionDirectory = Path.GetDirectoryName(projectSettingsPath);
			_scope = parentContainer.BeginLifetimeScope(builder =>
			{
				//BloomEvents are by nature, singletons (InstancePerLifetimeScope)
				builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
					.InstancePerLifetimeScope()
					// Didn't work .Where(t => t.GetInterfaces().Contains(typeof(Bloom.Event<>)));
					.Where(t => t is IEvent);

				//Other classes which are also  singletons
				builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
					.InstancePerLifetimeScope()
					.Where(t => new[]{
					typeof(TemplateInsertionCommand),
					typeof(DeletePageCommand),
					typeof(EditBookCommand),
					typeof(SendReceiveCommand),
					typeof(SelectedTabAboutToChangeEvent),
					typeof(SelectedTabChangedEvent),
					typeof(BookRenamedEvent),
					typeof(LibraryClosing),
					typeof(PageListChangedEvent),  // REMOVE+++++++++++++++++++++++++++
					typeof(BookRefreshEvent),
					typeof(BookSelection),
					typeof(CurrentEditableCollectionSelection),
					typeof(RelocatePageEvent),
					typeof(QueueRenameOfCollection),
					typeof(PageSelection),
					typeof(EditingModel)}.Contains(t));



				try
				{
					//nb: we split out the ChorusSystem.Init() so that this won't ever fail, so we have something registered even if we aren't
					//going to be able to do HG for some reason.
					var chorusSystem = new ChorusSystem(Path.GetDirectoryName(projectSettingsPath));
					builder.Register<ChorusSystem>(c => chorusSystem).InstancePerLifetimeScope();
					builder.Register<SendReceiver>(c => new SendReceiver(chorusSystem,()=>ProjectWindow)).InstancePerLifetimeScope();
					chorusSystem.Init(string.Empty/*user name*/);
				}
				catch (Exception error)
				{
					Palaso.Reporting.ErrorReport.NotifyUserOfProblem(error,
						"There was a problem loading the Chorus Send/Receive system for this collection. Bloom will try to limp along, but you'll need technical help to resolve this. If you have no other choice, find this folder: {0}, move it somewhere safe, and restart Bloom.", Path.GetDirectoryName(projectSettingsPath).CombineForPath(".hg"));
				}


				//This deserves some explanation:
				//*every* collection has a "*.BloomCollection" settings file. But the one we make the most use of is the one editable collection
				//That's why we're registering it... it gets used all over. At the moment (May 2012), we don't ever read the
				//settings file of the collections we're using for sources.
				try
				{
					builder.Register<CollectionSettings>(c => new CollectionSettings(projectSettingsPath)).InstancePerLifetimeScope();
				}
				catch(Exception)
				{
					return;
				}


				builder.Register<LibraryModel>(c => new LibraryModel(editableCollectionDirectory, c.Resolve<CollectionSettings>(), c.Resolve<SendReceiver>(), c.Resolve<BookSelection>(), c.Resolve<SourceCollectionsList>(), c.Resolve<BookCollection.Factory>(), c.Resolve<EditBookCommand>(),c.Resolve<CreateFromSourceBookCommand>(),c.Resolve<BookServer>(), c.Resolve<CurrentEditableCollectionSelection>())).InstancePerLifetimeScope();

				builder.Register<IChangeableFileLocator>(c => new BloomFileLocator(c.Resolve<CollectionSettings>(), c.Resolve<XMatterPackFinder>(), GetFileLocations())).InstancePerLifetimeScope();

				const int kListViewIconHeightAndSize = 70;
				builder.Register<HtmlThumbNailer>(c => new HtmlThumbNailer(kListViewIconHeightAndSize)).InstancePerLifetimeScope();

				builder.Register<LanguageSettings>(c =>
													{
														var librarySettings = c.Resolve<CollectionSettings>();
														var preferredSourceLanguagesInOrder = new List<string>();
														preferredSourceLanguagesInOrder.Add(librarySettings.Language2Iso639Code);
														if (!string.IsNullOrEmpty(librarySettings.Language3Iso639Code)
															&& librarySettings.Language3Iso639Code != librarySettings.Language2Iso639Code)
															preferredSourceLanguagesInOrder.Add(librarySettings.Language3Iso639Code);

														return new LanguageSettings(librarySettings.Language1Iso639Code, preferredSourceLanguagesInOrder);
													});
				builder.Register<XMatterPackFinder>(c =>
														{
															var locations = new List<string>();
															locations.Add(FileLocator.GetDirectoryDistributedWithApplication("xMatter"));
															locations.Add(XMatterAppDataFolder);
															return new XMatterPackFinder(locations);
														});

				builder.Register<SourceCollectionsList>(c =>
					 {
						 var l = new SourceCollectionsList(c.Resolve<Book.Book.Factory>(), c.Resolve<BookStorage.Factory>(), c.Resolve<BookCollection.Factory>(), editableCollectionDirectory);
						 l.RepositoryFolders = new string[] { FactoryCollectionsDirectory, InstalledCollectionsDirectory };
						 return l;
					 }).InstancePerLifetimeScope();

				builder.Register<ITemplateFinder>(c =>
					 {
						 return c.Resolve<SourceCollectionsList>();
					 }).InstancePerLifetimeScope();

				//TODO: this gave a stackoverflow exception
//				builder.Register<WorkspaceModel>(c => c.Resolve<WorkspaceModel.Factory>()(rootDirectoryPath)).InstancePerLifetimeScope();
				//so we're doing this
				builder.Register(c=>editableCollectionDirectory).InstancePerLifetimeScope();

				builder.RegisterType<CreateFromSourceBookCommand>().InstancePerLifetimeScope();


				builder.Register<Func<WorkspaceView>>(c => ()=>
													{
														var factory = c.Resolve<WorkspaceView.Factory>();
														if (projectSettingsPath.ToLower().Contains("web"))
														{
															return factory(c.Resolve<WebLibraryView>());
														}
														else
														{
															return factory(c.Resolve<LibraryView>());
														}
													});
			});

		}
		public static IEnumerable<string> GetFileLocations()
		{
			yield return Path.GetDirectoryName(FileLocator.GetDirectoryDistributedWithApplication("localization"));//hack to get the distfiles folder itself
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookEdit/js");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookEdit/css");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookEdit/html");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookEdit/img");

			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookPreview/js");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookPreview/css");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookPreview/html");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookPreview/img");

			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/bookLayout");
			yield return FileLocator.GetDirectoryDistributedWithApplication("BloomBrowserUI/collection");

			//yield return FileLocator.GetDirectoryDistributedWithApplication("widgets");

			yield return FileLocator.GetDirectoryDistributedWithApplication("xMatter");

			//yield return FileLocator.GetDirectoryDistributedWithApplication("xMatter", "Factory-XMatter");
			var templatesDir = Path.Combine(FactoryCollectionsDirectory, "Templates");

			yield return templatesDir;  //currently, this is where factory-xmatter.htm lives

			foreach (var templateDir in Directory.GetDirectories(templatesDir))
			{
				yield return templateDir;
			}

			yield return FactoryCollectionsDirectory;
			var samplesDir = Path.Combine(FactoryCollectionsDirectory, "Sample Shells");

			foreach (var dir in Directory.GetDirectories(samplesDir))
			{
				yield return dir;
			}

			//TODO: This is not going to cut it. The intent is to use the versino of a css from
			//the template directory, to aid the template developer (he/she will want to make tweaks in the
			//original, not the copies with sample data). But this is very blunt; we're throwing in every
			//template we can find; so the code which uses this big pot could easily link to the wrong thing
			//if 2 templates used the same name ("styles.css") or if there were different versions of the
			//template on the machine ("superprimer1/superprimer.css" and "superprimer2/superprimer.css").
			//Tangentially related is the problem of a stylesheet of a template changing and messing up
			//a users's existing just-fine document. We have to somehow address that, too.
			if (Directory.Exists(InstalledCollectionsDirectory))
			{
				foreach (var dir in Directory.GetDirectories(InstalledCollectionsDirectory))
				{
					yield return dir;
				}

				// add those directories from collections which are just pointed to by shortcuts
				foreach (var shortcut in Directory.GetFiles(InstalledCollectionsDirectory, "*.lnk", SearchOption.TopDirectoryOnly))
				{
					var collectionDirectory = ResolveShortcut.Resolve(shortcut);
					if (Directory.Exists(collectionDirectory))
					{
						foreach (var templateDirectory in Directory.GetDirectories(collectionDirectory))
						{
							yield return templateDirectory;
						}
					}
				}
			}

//			TODO: Add, in the list of places we look, this library's "regional library" (when such a concept comes into being)
//			so that things like IndonesiaA5Portrait.css work just the same as the Factory "A5Portrait.css"
//			var templateCollectionList = parentContainer.Resolve<SourceCollectionsList>();
//			foreach (var repo in templateCollectionList.RepositoryFolders)
//			{
//				foreach (var directory in Directory.GetDirectories(repo))
//				{
//					yield return directory;
//				}
//			}
		}
		private static string FactoryCollectionsDirectory
		{
			get { return FileLocator.GetDirectoryDistributedWithApplication("factoryCollections"); }
		}

		public static string InstalledCollectionsDirectory
		{
			get
			{
				//we want this path of directories sitting there, waiting for the user
				var d = GetBloomAppDataFolder();
				var collections = d.CombineForPath("Collections");
				if (!Directory.Exists(collections))
					Directory.CreateDirectory(collections);
				return collections;
			}
		}

		public static string XMatterAppDataFolder
		{
			get
			{
				//we want this path of directories sitting there, waiting for the user
				var d = GetBloomAppDataFolder();
				if (!Directory.Exists(d))
					Directory.CreateDirectory(d);
				d = d.CombineForPath("XMatter");
				if (!Directory.Exists(d))
					Directory.CreateDirectory(d);
				return d;
			}
		}

		public SendReceiver SendReceiver
		{
			get { return _scope.Resolve<SendReceiver>(); }
		}


		public static string GetBloomAppDataFolder()
		{
			var d = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).CombineForPath("SIL");
			if (!Directory.Exists(d))
				Directory.CreateDirectory(d);
			d = d.CombineForPath("Bloom");
			if (!Directory.Exists(d))
				Directory.CreateDirectory(d);
			return d;
		}



		/// ------------------------------------------------------------------------------------
		public void Dispose()
		{
			_scope.Dispose();
			_scope = null;

			if (_bloomServer != null)
				_bloomServer.Dispose();
			_bloomServer = null;
			if (_imageServer!=null)
				_imageServer.Dispose();
			_imageServer = null;
		}

		/// <summary>
		/// The idea here is that if someone is editing a shell collection, then next thing they are likely to do is
		/// open a vernacular library and try it out.  By adding this link, well they'll see this collection like
		/// they probably expect.
		/// </summary>
		private void AddShortCutInComputersBloomCollections(string vernacularCollectionDirectory)
		{
			if (!Directory.Exists(ProjectContext.InstalledCollectionsDirectory))
				return;//well, that would be a bug, I suppose...

			try
			{
				ShortcutMaker.CreateDirectoryShortcut(vernacularCollectionDirectory, ProjectContext.InstalledCollectionsDirectory);
			}
			catch (ApplicationException e)
			{
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(new ShowOncePerSessionBasedOnExactMessagePolicy(), e.Message);
			}
			catch (Exception e)
			{
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(e,
					"Could not add a link for this shell library in the user collections directory");
			}

		}

	}
}
