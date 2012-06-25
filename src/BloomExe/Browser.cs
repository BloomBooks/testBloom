﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using Palaso.IO;
using Palaso.Xml;
using Gecko;
using Gecko.DOM;
using TempFile = BloomTemp.TempFile;

namespace Bloom
{
	public partial class Browser : UserControl
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetDllDirectory(string lpPathName);

		protected GeckoWebBrowser _browser;
		bool _browserIsReadyToNavigate;
		private string _url;
		private XmlDocument _pageDom;
		private TempFile _tempHtmlFile;
		private PasteCommand _pasteCommand;
		private CopyCommand _copyCommand;
		private  UndoCommand _undoCommand;
		private  CutCommand _cutCommand;
		public event EventHandler OnBrowserClick;


		public static void SetUpXulRunner()
		{
			string xulRunnerPath = Path.Combine(FileLocator.DirectoryOfApplicationOrSolution, "xulrunner");
			if (!Directory.Exists(xulRunnerPath))
			{

				//if this is a programmer, go look in the lib directory
				xulRunnerPath = Path.Combine(FileLocator.DirectoryOfApplicationOrSolution,
											 Path.Combine("lib", "xulrunner"));

				//on my build machine, I really like to have the dir labelled with the version.
				//but it's a hassle to update all the other parts (installer, build machine) with this number,
				//so we only use it if we don't find the unnumbered alternative.
				if(!Directory.Exists(xulRunnerPath))
					xulRunnerPath = Path.Combine(FileLocator.DirectoryOfApplicationOrSolution,
												 Path.Combine("lib", "xulrunner11"));

				//NB: WHEN CHANGING VERSIONS, ALSO CHANGE IN THESE LOCATIONS:
				// get the new xulrunner, zipped (as it comes from mozilla), onto c:\builddownloads on the palaso teamcity build machine
				//	build/build.win.proj: change the zip file to match the new name


			}
			//Review: an early tester found that wrong xpcom was being loaded. The following solution is from http://www.geckofx.org/viewtopic.php?id=74&action=new
			SetDllDirectory(xulRunnerPath);

			Gecko.Xpcom.Initialize(xulRunnerPath);
		}

		public Browser()
		{
			InitializeComponent();
		}

		public void SetEditingCommands( CutCommand cutCommand, CopyCommand copyCommand, PasteCommand pasteCommand, UndoCommand undoCommand)
		{
			_cutCommand = cutCommand;
			_copyCommand = copyCommand;
			_pasteCommand = pasteCommand;
			_undoCommand = undoCommand;

			_cutCommand.Implementer = () => _browser.CutSelection();
			_copyCommand.Implementer = () => _browser.CopySelection();
			_pasteCommand.Implementer = () =>
											{
												_browser.Paste();
											};
			_undoCommand.Implementer = () => _browser.Undo();

			//none of these worked
/*            _browser.DomKeyPress+=new GeckoDomKeyEventHandler((sender, args) => UpdateEditButtons());
			_browser.DomClick += new GeckoDomEventHandler((sender, args) => UpdateEditButtons());
			_browser.DomFocus += new GeckoDomEventHandler((sender, args) => UpdateEditButtons());
  */      }

		public void SaveHTML(string path)
		{
			_browser.SaveDocument(path, "text/html");
		}

		private void UpdateEditButtons()
		{
			if (_copyCommand == null)
				return;

			_cutCommand.Enabled = _browser != null && _browser.CanCutSelection;
			_copyCommand.Enabled = _browser != null && _browser.CanCopySelection;
			_pasteCommand.Enabled = _browser != null && _browser.CanPaste;
			if(_pasteCommand.Enabled)
			{
				//prevent pasting images (BL-93)
				_pasteCommand.Enabled = Clipboard.ContainsText();
			}
			_undoCommand.Enabled = _browser != null && _browser.CanUndo;
		}

		void OnValidating(object sender, CancelEventArgs e)
		{
			LoadPageDomFromBrowser();
			//_afterValidatingTimer.Enabled = true;//LoadPageDomFromBrowser();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (_tempHtmlFile != null)
			{
				_tempHtmlFile.Dispose();
				_tempHtmlFile = null;
			}
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		public GeckoWebBrowser WebBrowser { get { return _browser; } }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if(DesignMode)
			{
				this.BackColor=Color.DarkGray;
				return;
			}

			_browser = new GeckoWebBrowser();

			_browser.Parent = this;
			_browser.Dock = DockStyle.Fill;
			Controls.Add(_browser);
			_browser.NoDefaultContextMenu = true;
			_browser.ShowContextMenu += new EventHandler<GeckoContextMenuEventArgs>(OnShowContextMenu);

			_browser.Navigating += new EventHandler<GeckoNavigatingEventArgs>(_browser_Navigating);
		   // NB: registering for domclicks seems to stop normal hyperlinking (which we don't
			//necessarily need).  When I comment this out, I get an error if the href had, for example,
			//"bloom" for the protocol.  We could probably install that as a protocol, rather than
			//using the click to just get a target and go from there, if we wanted.
			_browser.DomClick += new EventHandler<GeckoDomEventArgs>(OnBrowser_DomClick);

			_browser.DomKeyPress += new EventHandler<GeckoDomKeyEventArgs>(OnDomKeyPress);
			_browserIsReadyToNavigate = true;

			UpdateDisplay();
			_browser.Validating += new CancelEventHandler(OnValidating);
			_browser.Navigated += CleanupAfterNavigation;//there's also a "document completed"
			//_browser.DocumentCompleted += new EventHandler(_browser_DocumentCompleted);

			_updateCommandsTimer.Enabled = true;//hack
			var errorsToHide = new List<string>();
			errorsToHide.Add("['Shockwave Flash'] is undefined"); // can happen when mootools (used by calendar) is loaded
			//after swalling that one, you just get another... do this for now
			errorsToHide.Add("mootools"); // can happen when mootools (used by calendar) is loaded

			errorsToHide.Add("PlacesCategoriesStarter.js"); //happens if you let bloom sit there long enough

			errorsToHide.Add("PlacesDBUtils"); //happens if you let bloom sit there long enough

			errorsToHide.Add("privatebrowsing"); //no idea why it shows this error sometimes

			//again, more generally
			errorsToHide.Add("xulrunner"); // can happen when mootools (used by calendar) is loaded


			//This one started appearing, only on the ImageOnTop pages, when I introduced jquery.resize.js
			//and then added the ResetRememberedSize() function to it. So it's my fault somehow, but I haven't tracked it down yet.
			//it will continue to show in firebug, so i won't forget about it

			errorsToHide.Add("jquery.js at line 622");
			WebBrowser.JavascriptError += (sender, error) =>
			{
				var msg = string.Format("There was a JScript error in {0} at line {1}: {2}",
										error.Filename, error.Line, error.Message);
				if (!errorsToHide.Any(matchString => msg.Contains(matchString)))
					Palaso.Reporting.ErrorReport.NotifyUserOfProblem(msg);
			};

			GeckoPreferences.User["mousewheel.withcontrolkey.action"] = 3;
			GeckoPreferences.User["browser.zoom.full"] = true;

			RaiseGeckoReady();
	   }

		/// <summary>
		/// Prevent a CTRL+V pasting when we have the Paste button disabled, e.g. when pictures are on the clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDomKeyPress(object sender, GeckoDomKeyEventArgs e)
		{
			if (e.CtrlKey && e.KeyChar == 'v')
			{
				if (!_pasteCommand.Enabled)
				{
					e.PreventDefault();
				}
				else if(_browser.CanPaste && Clipboard.ContainsText())
				{
					e.PreventDefault(); //we'll take it from here, thank you very much

					//filter whatever's on there down to just simple text.
					//While it's tempting to allow formatted pasting, if you're making a shell, that's just
					//kidding yourself; the translator won't get to have that formatting too.
					var originalText = Clipboard.GetText(TextDataFormat.UnicodeText);
					Clipboard.SetText(originalText,TextDataFormat.UnicodeText);
					_browser.Paste();
				}
			}
		}

		void OnShowContextMenu(object sender, GeckoContextMenuEventArgs e)
		{
			var m = e.ContextMenu.MenuItems.Add("Edit Stylesheets in Stylizer", new EventHandler(OnOpenPageInStylizer));
			m.Enabled = !string.IsNullOrEmpty(GetPathToStylizer());

			e.ContextMenu.MenuItems.Add("Open Page in System Browser", new EventHandler(OnOpenPageInSystemBrowser));
		}

		public void OnOpenPageInSystemBrowser(object sender, EventArgs e)
		{
			var  temp = Palaso.IO.TempFile.WithExtension(".htm");
			File.Copy(_url, temp.Path,true); //we make a copy because once Bloom leaves this page, it will delete it, which can be an annoying thing to have happen your editor
			Process.Start(temp.Path);
		}

		public void OnOpenPageInStylizer(object sender, EventArgs e)
		{
			string path = Path.GetTempFileName();
			File.Copy(_url, path,true); //we make a copy because once Bloom leaves this page, it will delete it, which can be an annoying thing to have happen your editor
			Process.Start(GetPathToStylizer(), path);
		}
		public static string GetPathToStylizer()
		{
			return FileLocator.LocateInProgramFiles("Stylizer.exe", false, new string[] { "Skybound Stylizer 5" });
		}



		void OnBrowser_DomClick(object sender, GeckoDomEventArgs e)
		{
			EventHandler handler = OnBrowserClick;
			if (handler != null)
				handler(this, e);
		}


		void _browser_Navigating(object sender, GeckoNavigatingEventArgs e)
		{
			if (e.Uri.OriginalString.ToLower().StartsWith("http") && !e.Uri.OriginalString.ToLower().Contains("bloom"))
			{
				e.Cancel = true;
				Process.Start(e.Uri.OriginalString); //open in the system browser instead
			}

			Debug.WriteLine("Navigating " + e.Uri);
		}

		private void CleanupAfterNavigation(object sender, GeckoNavigatedEventArgs e)
		{
		   //NO. We want to leave it around for debugging purposes. It will be deleted when the next page comes along, or when this class is disposed of
//    		if(_tempHtmlFile!=null)
//    		{
//				_tempHtmlFile.Dispose();
//    			_tempHtmlFile = null;
//    		}
			//didn't seem to do anything:  _browser.WebBrowserFocus.SetFocusAtFirstElement();
		}

		public void Navigate(string url, bool cleanupFileAfterNavigating)
		{
			_url=url; //TODO: fix up this hack. We found that deleting the pdf while we're still showing it is a bad idea.
			if(cleanupFileAfterNavigating && !_url.EndsWith(".pdf"))
			{
				SetNewTempFile(TempFile.TrackExisting(url));
			}
			UpdateDisplay();
		}

		//NB: make sure the <base> is set correctly, 'cause you don't know where this method will
		//save the file before navigating to it.
		public void Navigate(XmlDocument dom)
		{
			_pageDom = dom;
			XmlHtmlConverter.MakeXmlishTagsSafeForInterpretationAsHtml(dom);
			SetNewTempFile(TempFile.CreateHtm5FromXml(dom));
			_url = _tempHtmlFile.Path;
			UpdateDisplay();
		}

		private void SetNewTempFile(TempFile tempFile)
		{
			if(_tempHtmlFile!=null)
			{
				try
				{
					_tempHtmlFile.Dispose();
				}
				catch(Exception)
				{
						//not worth talking to the user about it. Just abandon it in the Temp directory.
#if DEBUG
					throw;
#endif
				}

			}
			_tempHtmlFile = tempFile;
		}



		private void UpdateDisplay()
		{
			if (!_browserIsReadyToNavigate)
				return;

			if (_url!=null)
			{
				_browser.Visible = true;
				_browser.Navigate(_url);
			}
		}


		private void _afterValidatingTimer_Tick(object sender, EventArgs e)
		{
			_afterValidatingTimer.Enabled = false;
			//LoadPageDomFromBrowser();
		}
		/// <summary>
		/// What's going on here: the browser is just /editting displaying a copy of one page of the document.
		/// So we need to copy any changes back to the real DOM.
		/// </summary>
		private void LoadPageDomFromBrowser()
		{
			if (_pageDom == null)
				return;

			//this is to force an onblur so that we can get at the actual user-edited value [review: still needed? maybe for textareas]
			_browser.WebBrowserFocus.Deactivate();
			_browser.WebBrowserFocus.Activate();


			var body = _browser.Document.GetElementsByTagName("body");
			if (body.Count ==0)	//review: this does happen... onValidating comes along, but there is no body. Assuming it is a timing issue.
				return;

			var content = body[0].InnerHtml;
			XmlDocument dom;

			//todo: deal with exception that can come out of this
			try
			{
				dom = XmlHtmlConverter.GetXmlDomFromHtml(content);
				var bodyDom = dom.SelectSingleNode("//body");

				if (_pageDom == null)
					return;

				var destinationDomPage = _pageDom.SelectSingleNode("//body/div[contains(@class,'bloom-page')]");
				if (destinationDomPage == null)
					return;
				var expectedPageId = destinationDomPage["id"];

				var browserPageId = bodyDom.SelectSingleNode("//body/div[contains(@class,'bloom-page')]");
				if (browserPageId == null)
					return;//why? but I've seen it happen

				var thisPageId = browserPageId["id"];
				if(expectedPageId != thisPageId)
				{
					Palaso.Reporting.ErrorReport.NotifyUserOfProblem("Bloom encountered an error saving that page (unexpected page id)");
					return;
				}
				_pageDom.GetElementsByTagName("body")[0].InnerXml = bodyDom.InnerXml;

				//enhance: we have jscript for this: cleanup()... but running jscript in this method was leading the browser to show blank screen
//				foreach (XmlElement j in _pageDom.SafeSelectNodes("//div[contains(@class, 'ui-tooltip')]"))
//				{
//					j.ParentNode.RemoveChild(j);
//				}
//				foreach (XmlAttribute j in _pageDom.SafeSelectNodes("//@ariasecondary-describedby | //@aria-describedby"))
//				{
//					j.OwnerElement.RemoveAttributeNode(j);
//				}

			}
			catch(Exception e)
			{
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(e, "Sorry, Bloom choked on something on this page (invalid incoming html).\r\n\r\n+{0}", e);
				return;
			}



			try
			{
				XmlHtmlConverter.ThrowIfHtmlHasErrors(_pageDom.OuterXml);
			}
			catch (Exception e)
			{
				var exceptionWithHtmlContents = new Exception(content);
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(e, "Sorry, Bloom choked on something on this page (validating page).\r\n\r\n+{0}", e.Message);
			}

		}

		private void OnUpdateDisplayTick(object sender, EventArgs e)
		{
			UpdateEditButtons();
		}

		/// <summary>
		/// This is needed if we want to save before getting a natural Validating event.
		/// </summary>
		public void ReadEditableAreasNow()
		{
			if (_url != "about:blank")
			{
				RunJavaScript("Cleanup()");
					//nb: it's important not to move this into LoadPageDomFromBrowser(), which is also called during validation, becuase it isn't allowed then
				LoadPageDomFromBrowser();
			}
		}

		public void Copy()
		{
			_browser.CopySelection();
		}

		/// <summary>
		/// add a jscript source file
		/// </summary>
		/// <param name="filename"></param>
		public void AddScriptSource(string filename)
		{
			if (!File.Exists(Path.Combine(Path.GetDirectoryName(_url), filename)))
				throw new FileNotFoundException(filename);

			GeckoDocument doc = WebBrowser.Document;
			var head = doc.GetElementsByTagName("head").First();
			GeckoScriptElement script = doc.CreateElement("script") as GeckoScriptElement;
			script.Type = "text/javascript";
			script.Src = filename;
			head.AppendChild(script);
		}

		public void AddScriptContent(string content)
		{
			GeckoDocument doc = WebBrowser.Document;
			var head = doc.GetElementsByTagName("head").First();
			GeckoScriptElement script = doc.CreateElement("script") as GeckoScriptElement;
			script.Type = "text/javascript";
			script.Text = content;
			head.AppendChild(script);
		}

		public void RunJavaScript(string script)
		{
			//NB: someday, look at jsdIDebuggerService, which has an Eval

			//TODO: work on getting the ability to get a return value: http://chadaustin.me/2009/02/evaluating-javascript-in-an-embedded-xulrunnergecko-window/ , EvaluateStringWithValue, nsiscriptcontext,


			WebBrowser.Navigate("javascript:void(" +script+")");
			// from experimentation (at least with a script that shows an alert box), the script isn't run until this happens:
			//var filter = new TestMessageFilter();
			//Application.AddMessageFilter(filter);
				Application.DoEvents();


			//NB: Navigating and Navigated events are never raised. I'm going under the assumption for now that the script blocks
	   }



		/* snippets
		 *
		 * //           _browser.WebBrowser.Navigate("javascript:void(document.getElementById('output').innerHTML = 'test')");
//            _browser.WebBrowser.Navigate("javascript:void(alert($.fn.jquery))");
//            _browser.WebBrowser.Navigate("javascript:void(alert($(':input').serialize()))");
			//_browser.WebBrowser.Navigate("javascript:void(document.getElementById('output').innerHTML = form2js('form','.',false,null))");
			//_browser.WebBrowser.Navigate("javascript:void(alert($(\"form\").serialize()))");

			*/
		public event EventHandler GeckoReady;

		public void RaiseGeckoReady()
		{
			EventHandler handler = GeckoReady;
			if (handler != null) handler(this, null);
		}

		public void ShowHtml(string html)
		{
			_browser.LoadHtml(html);
		}
	}

}
