﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using Bloom.Book;
using Bloom.Properties;
using L10NSharp;

namespace Bloom.Edit
{
	public partial class ThumbNailList : UserControl
	{
		private bool _inSelectionAlready;
		private bool _intentionallyChangingSelection;


		private ListViewItem _currentDraggingItem;
		private ListViewItem _currentTarget;
		private Pen _boundsPen;
		private int _numberofEmptyListItemsAtStart;
		public HtmlThumbNailer Thumbnailer;
		private Image _placeHolderImage;
		public event EventHandler PageSelectedChanged;

		public ThumbNailList()
		{
			InitializeComponent();
			this.Font = new System.Drawing.Font(SystemFonts.DialogFont.FontFamily, 9F);
			_listView.LargeImageList = _thumbnailImageList;
			_listView.Sorting = SortOrder.Ascending;
			_listView.ListViewItemSorter = new SortListViewItemByIndex();
			  _listView.OwnerDraw = true;
			 _listView.DrawItem+=new DrawListViewItemEventHandler(_listView_DrawItem);
			 _boundsPen = new Pen(Brushes.DarkGray, 2);

			_placeHolderImage = new Bitmap(32, 32);

		}

		void _listView_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
			if (e.Item == _currentTarget && e.Item != _currentDraggingItem)
			{
				e.Graphics.DrawLine(Pens.Red, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Left, e.Bounds.Top);
			}
			//indicate selection in a more obvious way than just the grey screen we get by default
			if(e.Item.Selected )
			{
				var r = e.Bounds;
				r.Inflate(-1,-1);
				e.Graphics.DrawRectangle(_boundsPen,r);
			}


			if (e.Item == ItemWhichWouldPrecedeANewPageInsertion)
			{
				e.Graphics.DrawLine(Pens.White, e.Bounds.Right-8, e.Bounds.Bottom-2, e.Bounds.Right-5, e.Bounds.Bottom-6);
				e.Graphics.DrawLine(Pens.White, e.Bounds.Right - 2, e.Bounds.Bottom-2, e.Bounds.Right - 5, e.Bounds.Bottom - 6);
			}
		}

		public bool KeepShowingSelection
		{
			set
			{
				//_listView.HideSelection = !value;
			}
		}

	   private void InvokePageSelectedChanged(Page page)
		{
			EventHandler handler = PageSelectedChanged;
			if (handler != null && /*REVIEW */ page!=null )
			{
				handler(page, null);
			}
		}
		public void SetItems(IEnumerable<IPage> items)
		{
			_listView.ListViewItemSorter = null;
			SuspendLayout();
			_listView.BeginUpdate();
			_listView.Items.Clear();
			_thumbnailImageList.Images.Clear();

			_numberofEmptyListItemsAtStart = 0;
			int pageNumber = 0;
			foreach (IPage page in items)
			{
				if (_listView == null)//hack... once I saw this go null in the middle of working, when I tabbed away from the control
					return;

				if (page is PlaceHolderPage)
					++_numberofEmptyListItemsAtStart;

				AddOnePage(page, ref pageNumber);
			}
			_listView.ListViewItemSorter = new SortListViewItemByIndex();
			_listView.EndUpdate();
			ResumeLayout();
		}

		public void UpdateThumbnailCaptions()
		{
			_listView.BeginUpdate();
			int pageNumber = 0;
			foreach (ListViewItem item in _listView.Items)
			{
				IPage page = (IPage) item.Tag;
				var captionOrPageNumber = page.GetCaptionOrPageNumber(ref pageNumber);
				item.Text = LocalizationManager.GetDynamicString("Bloom", "EditTab.ThumbnailCaptions."+captionOrPageNumber, captionOrPageNumber);
			}
			_listView.EndUpdate();
		}

		private void AddOnePage(IPage page, ref int pageNumber)
		{
			var label = PreferPageNumbers ? page.GetCaptionOrPageNumber(ref pageNumber) : page.Caption;
			label = LocalizationManager.GetDynamicString("Bloom", "EditTab.ThumbnailCaptions." + label, label);

			ListViewItem item = new ListViewItem(label, 0);
			item.Tag = page;

			Image thumbnail = Resources.PagePlaceHolder; ;
			if (page is PlaceHolderPage)
				thumbnail = _placeHolderImage;
			_thumbnailImageList.Images.Add(page.Id, thumbnail);
			item.ImageIndex = _thumbnailImageList.Images.Count - 1;
			_listView.Items.Add(item);
			if (!(page is PlaceHolderPage))
			{
				UpdateThumbnailAsync(page);
			}
		}

		public void UpdateThumbnailAsync(IPage page)
		{
			XmlDocument pageDom = page.Book.GetPreviewXmlDocumentForPage(page).RawDom;

			Thumbnailer.GetThumbnailAsync(String.Empty, page.Id, pageDom,
													  Palette.TextAgainstDarkBackground,
													  false, image => RefreshOneThumbnailCallback(page, image),
													  error=> HandleThumbnailerError(page, error));
		}

		private void HandleThumbnailerError(IPage page, Exception error)
		{
#if DEBUG

			//NOTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			//Javascript errors in the *editable* page (the one on screen) can show up here. Bizarre... haven't figured out how/why. Maybe due to calling application.doevents()
			//in the thumbnail generator. Symptom is that even passing a blank html file to the thumbnailer still gives javascript errors here, but taking the javascript out of
			//the editable page (in Book.GetEditableHtmlDomForPage() ) fixes it.
			//Note, even though you'll get the error once for everythumbnail, don't let that fool you.

			Debug.Fail("Debug only" + error.Message);
#endif
			RefreshOneThumbnailCallback(page, Resources.Error70x70);
		}

		private void RefreshOneThumbnailCallback(IPage page, Image image)
		{
			if (IsDisposed)
				return;
			var imageIndex = _thumbnailImageList.Images.IndexOfKey(page.Id);
			if (imageIndex > -1)
			{
				_thumbnailImageList.Images[imageIndex] = image;

				//at one time the page we just inserted would have the same id, but be a different IPage object.
				//Now, the above checks for id equality too (never did track down why the objects change, but this is robust, so I'm not worried about it)

				var listItem = (from ListViewItem i in _listView.Items where ((i.Tag == page) || ((IPage)i.Tag).Id == page.Id) select i).FirstOrDefault();
				if(listItem!=null)
				{
					_listView.Invalidate(listItem.Bounds);
				}
				else
				{
					Debug.Fail("Did not find a matching page."); //theoretically, this could happen if you managed to delete the page before its thumnbail could be built
					var lastPage = _listView.Items[_listView.Items.Count - 1];
				}

			}
		}


		public bool CanSelect { get; set; }
		public bool PreferPageNumbers { get; set; }

		public RelocatePageEvent RelocatePageEvent { get; set; }

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_inSelectionAlready)
				return;
			if (!_intentionallyChangingSelection)//yes, having painful phantom selections when the cursor leaves this control
			{
				_listView.SelectedIndices.Clear();
			}

			_inSelectionAlready = true;
			try
			{
				if (_listView.SelectedItems.Count == 0)
				{
					InvokePageSelectedChanged(null);
				}
				else
				{
					Page page = _listView.SelectedItems[0].Tag as Page;
					if(!CanSelect)
					{
						//leads to two apparent clicks... (hence the _mouseDidGoDown thing)
						_listView.SelectedIndices.Clear();
					}
					InvokePageSelectedChanged(page);
				}
			}
			finally
			{
				_inSelectionAlready = false;
			}
		}

		private void ThumbNailList_BackColorChanged(object sender, EventArgs e)
		{
			_listView.BackColor = BackColor;
		}

		private void _listView_MouseDown(object sender, MouseEventArgs e)
		{
			_intentionallyChangingSelection = true;
			//_mouseDownLocation = e.Location;
			if (this.RelocatePageEvent !=null)
			{
				var listItem = _listView.GetItemAt(e.X, e.Y);
				if (listItem == null)
					return;
				if (!((IPage)listItem.Tag).CanRelocate)
				{
					return;
				}
				Capture = true;

				_currentDraggingItem = listItem;
				Cursor = Cursors.Hand;
			}
		}

		/// <summary>
		/// used to visually indicate where the page would show up, if we add a new one
		/// </summary>
		public ListViewItem ItemWhichWouldPrecedeANewPageInsertion
		{
			get; set;
		}

		private void _listView_MouseUp(object sender, MouseEventArgs e)
		{
//            if (_mouseDownLocation == default(Point))
//            {
//                _currentTarget = null;
//                _currentDraggingItem = null;
//                return;
//            }
//
//		    var mouseDownLocation = _mouseDownLocation;
//		    _mouseDownLocation = default(Point);

			Capture = false;
			Debug.WriteLine("MouseUp");
			_intentionallyChangingSelection = false;

			if (Control.MouseButtons == MouseButtons.Left)
				return;

			Cursor = Cursors.Default;

			bool notPointingAtOriginalLocation= _listView.GetItemAt(e.X, e.Y) != _currentDraggingItem;

//		    var horizontalMovement = Math.Abs(mouseDownLocation.X - e.X);
//            var verticalMovement = Math.Abs(mouseDownLocation.Y - e.Y);
//		    bool sufficientDistance = horizontalMovement > _thumbnailImageList.ImageSize.Width
//                || verticalMovement > _thumbnailImageList.ImageSize.Height;

			if (notPointingAtOriginalLocation &&  RelocatePageEvent != null && _currentDraggingItem != null)
			{
				Debug.WriteLine("Re-ordering");
				if (_currentTarget == null ||
						_currentTarget == _currentDraggingItem) //should never happen, but to be safe
				{
					_currentTarget = null;
					_currentDraggingItem = null;
					return;
				}

				var relocatePageInfo = new RelocatePageInfo((IPage) _currentDraggingItem.Tag, _currentTarget.Index - _numberofEmptyListItemsAtStart);
				RelocatePageEvent.Raise(relocatePageInfo);
				if (relocatePageInfo.Cancel)
					return;

				_listView.BeginUpdate();
				_listView.Items.Remove(_currentDraggingItem);
				_listView.Items.Insert(_currentTarget.Index, _currentDraggingItem);
				_listView.EndUpdate();
				_currentTarget = null;
				_currentDraggingItem = null;

				UpdateThumbnailCaptions();
				_listView.Invalidate();
			}
			else
			{
				_currentTarget = null;
				_currentDraggingItem = null;
			}
		}


		private void _listView_MouseMove(object sender, MouseEventArgs e)
		{

			if (_listView.GetItemAt(e.X, e.Y) == _currentDraggingItem)
				return; //not really a "move" if we're still pointing at the original item

			if (this.RelocatePageEvent != null && _currentDraggingItem != null)
			{
				if (Control.MouseButtons != MouseButtons.Left)
				{
//hack trying to get a correct notion of when the mouse is up
					_listView_MouseUp(null, e);
					return;
				}

				Debug.WriteLine("Dragging");
				Cursor = Cursors.Hand;
				ListViewItem  target=null;
				if (null == _listView.GetItemAt(e.X, e.Y))
				{
					target = _listView.GetItemAt(e.X+20, e.Y);
				}
				else
				{
					target = _listView.GetItemAt(e.X, e.Y);
				}

				if (target == null)
				{
					//when we point right in the middle, we'll get a null target, but we sure want one,
					//so try looking to one side

					Debug.WriteLine("null target");
				}
				else
				{
					Debug.WriteLine("target: " + target.Text);

					//if we're pointing to the right of some item, we want to insert *after* it.
					var middle = target.Position.X + (_thumbnailImageList.ImageSize.Width/2);
					if (e.X > middle && _listView.Items.Count - 1 > target.Index)
					{
						target = _listView.Items[target.Index + 1]; //choose the next item
					}
				}
				if (_currentDraggingItem == target)//doesn't count to drag on yourself
				{
					return;
				}

				if (target != _currentTarget)
				{
					_listView.Invalidate(); //repaint
				}
				_currentTarget = target;
			}
		}

		public void SelectPage(IPage page)
		{
			if (_listView == null)
				return;

			foreach (ListViewItem listViewItem in _listView.Items)
			{
				var itemPage = listViewItem.Tag as IPage;
				if (itemPage == null)
					continue;

				if(itemPage.Id == page.Id) //actual page object may change between book loads, but the id is consistent
				{
					try
					{
						_intentionallyChangingSelection = true;
						listViewItem.Selected = true;
						ItemWhichWouldPrecedeANewPageInsertion = listViewItem;
						listViewItem.EnsureVisible();
					}
					finally
					{
						_intentionallyChangingSelection = false;
					}
					return;
				}
			}
// actually, this is common because we might not yet have been told to update our list   Debug.Fail("Did not find item to select");
		}

		public void SetPageInsertionPoint(IPage pageBeforeInsertion)
		{
			ItemWhichWouldPrecedeANewPageInsertion = _listView.Items.OfType<ListViewItem>().FirstOrDefault(i => i.Tag == pageBeforeInsertion);
		}

		public void EmptyThumbnailCache()
		{
			foreach (ListViewItem item in _listView.Items)
			{

				var pageId = (item.Tag as IPage).Id;
				if(!(item.Tag is PlaceHolderPage))
					Thumbnailer.PageChanged(pageId);
			}
		}
	}

	/// <summary>
	/// This makes a list view act, well, like one would expect; the items
	/// are ordered according to their index, so that inserting an item actually
	/// does something other than always throwing it at the end!
	/// </summary>
	class SortListViewItemByIndex : IComparer
	{
		public int Compare(object x, object y)
		{
			ListViewItem X = x as ListViewItem;
			ListViewItem Y = y as ListViewItem;
			ListView listView = X.ListView;
			if (listView != null && X != null && Y != null)
			{
				return listView.Items.IndexOf(X) - listView.Items.IndexOf(Y);
			}
			return 0;
		}
	}
}
