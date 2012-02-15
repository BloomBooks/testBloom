using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Bloom.Book;
using Bloom.Library;
using Bloom.web;

namespace Bloom
{
	public interface ITemplateFinder
	{
		Book.Book FindTemplateBook(string key);
	}

	public class StoreCollectionList : ITemplateFinder
	{
		private readonly Book.Book.Factory _bookFactory;
		private readonly BookStorage.Factory _storageFactory;
		private readonly BookCollection.Factory _bookCollectionFactory;

		//for moq'ing
		public StoreCollectionList(){}

		public StoreCollectionList(Book.Book.Factory bookFactory, BookStorage.Factory storageFactory, BookCollection.Factory bookCollectionFactory)
		{
			_bookFactory = bookFactory;
			_storageFactory = storageFactory;
			_bookCollectionFactory = bookCollectionFactory;

		}

		public IEnumerable<string> RepositoryFolders
		{
			get;
			set;
		}

		public Book.Book FindTemplateBook(string key)
		{
			foreach (var root in RepositoryFolders)
			{
				if (!Directory.Exists(root))
					continue;
				foreach (var collection in Directory.GetDirectories(root))
				{
					//TODO: dereference shortcuts to folders living elsewhere

					foreach (var templateDir in Directory.GetDirectories(collection))
					{
						if (Path.GetFileName(templateDir) == key)
							return _bookFactory(_storageFactory(templateDir), false);
								//review: this is loading the book both in the librarymodel, and here
					}
				}
			}
			return null;
		}

		public virtual IEnumerable<BookCollection> GetStoreCollections()
		{
			foreach (var root in RepositoryFolders)
			{
				if (!Directory.Exists(root))
					continue;

				foreach (var dir in Directory.GetDirectories(root))
				{
					if (Path.GetFileName(dir).StartsWith(".")) //skip thinks like .idea, .hg, etc.
						continue;
					yield return _bookCollectionFactory(dir, BookCollection.CollectionType.TemplateCollection);
				}

				//follow shortcuts
				foreach (var shortcut in Directory.GetFiles(root, "*.lnk", SearchOption.TopDirectoryOnly))
				{
					var path = ResolveShortcut.Resolve(shortcut);
					if (Directory.Exists(path))
						yield return _bookCollectionFactory(path, BookCollection.CollectionType.TemplateCollection);
				}
			}
		}
	}
}