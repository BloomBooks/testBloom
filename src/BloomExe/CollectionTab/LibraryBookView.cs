﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bloom.Book;
using Bloom.SendReceive;

namespace Bloom.CollectionTab
{
	/// <summary>
	/// this is an un-editable preview of a book in the library; either vernacular or template
	/// </summary>
	public partial class LibraryBookView : UserControl
	{
		private readonly BookSelection _bookSelection;
		private readonly SendReceiver _sendReceiver;
		private readonly CreateFromSourceBookCommand _createFromSourceBookCommand;
		private readonly EditBookCommand _editBookCommand;
		private bool _reshowPending = false;
		private bool _visible;

		public delegate LibraryBookView Factory();//autofac uses this

		public LibraryBookView(BookSelection bookSelection,
			SendReceiver sendReceiver,
			CreateFromSourceBookCommand createFromSourceBookCommand,
			EditBookCommand editBookCommand,
			SelectedTabChangedEvent selectedTabChangedEvent)
		{
			InitializeComponent();
			_bookSelection = bookSelection;
			_sendReceiver = sendReceiver;
			_createFromSourceBookCommand = createFromSourceBookCommand;
			_editBookCommand = editBookCommand;
			bookSelection.SelectionChanged += new EventHandler(OnBookSelectionChanged);

			selectedTabChangedEvent.Subscribe(c =>
												{
													_visible = c.To is LibraryView;
													if(_reshowPending)
													{
														ShowBook();
													}
												});
			_editBookButton.Visible = false;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			LoadBook();
		}

		void OnBookSelectionChanged(object sender, EventArgs e)
		{
			try
			{
				LoadBook();
			}
			catch (Exception error)
			{
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(error,"Problem selecting book");
			}
		}

		private void LoadBook()
		{
			_editBookButton.Visible = _addToCollectionButton.Visible =  _addToCollectionButton.Enabled = _bookSelection.CurrentSelection != null;
			ShowBook();
			if (_bookSelection.CurrentSelection != null)
			{
				_bookSelection.CurrentSelection.ContentsChanged += new EventHandler(CurrentSelection_ContentsChanged);
			}
		}

		void CurrentSelection_ContentsChanged(object sender, EventArgs e)
		{
			if(_visible)
				ShowBook();
			else
			{
				_reshowPending = true;
			}
		}

		private void ShowBook()
		{
			if (_bookSelection.CurrentSelection == null)
			{
				Debug.WriteLine("LibraryBookView.ShowBook() currentselection is null");
				_browser.Navigate("about:blank", false);
				_browser.Visible = false;
				BackColor = Color.FromArgb(64,64,64);
			}
			else
			{
				Debug.WriteLine("LibraryBookView.ShowBook() currentselection ok");

				_browser.Visible = true;
				_browser.Navigate(_bookSelection.CurrentSelection.GetPreviewHtmlFileForWholeBook().RawDom);
				_addToCollectionButton.Visible = _bookSelection.CurrentSelection.IsShellOrTemplate && !_bookSelection.CurrentSelection.HasFatalError;
				_editBookButton.Visible = _bookSelection.CurrentSelection.IsEditable && !_bookSelection.CurrentSelection.HasFatalError;
				_reshowPending = false;
			}
		}

		private void OnAddToLibraryClick(object sender, EventArgs e)
		{
			if (_bookSelection.CurrentSelection != null)
			{
				try
				{
					//nb: don't move this to after the raise command, as the selection changes
					var checkinNotice = string.Format("Created book from '{0}'", _bookSelection.CurrentSelection.TitleBestForUserDisplay);

					_createFromSourceBookCommand.Raise(_bookSelection.CurrentSelection);
					_sendReceiver.CheckInNow(checkinNotice);
				}
				catch(Exception error)
				{
					Palaso.Reporting.ErrorReport.NotifyUserOfProblem(error,"Bloom could not add that book to the library.");
				}
			}
		}

		private void _addToLibraryButton_MouseEnter(object sender, EventArgs e)
		{
//            _addToLibraryButton.Text = string.Format("Add this book to {0}", _librarySettings.VernacularCollectionNamePhrase);
//            _addToLibraryButton.Width = 250;
		}

		private void _addToLibraryButton_MouseLeave(object sender, EventArgs e)
		{
//            _addToLibraryButton.Text="";
//            _addToLibraryButton.Width = 50;
		}

		private void _editBookButton_Click(object sender, EventArgs e)
		{
			_editBookCommand.Raise(_bookSelection.CurrentSelection);
		}

		private void LibraryBookView_Resize(object sender, EventArgs e)
		{

		}

	}
}
