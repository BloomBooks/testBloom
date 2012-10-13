﻿namespace Bloom.CollectionTab
{
	partial class LibraryListView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryListView));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._updateThumbnailMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._updateFrontMatterToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._openFolderOnDisk = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._bookThumbnails = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this._sourcePaneMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this._keepFocusTimer = new System.Windows.Forms.Timer(this.components);
			this._localizationExtender = new Localization.UI.LocalizationExtender(this.components);
			this._vernacularCollectionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._showHistoryMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._showNotesMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new Bloom.ToPalaso.BetterSplitContainer(this.components);
			this._libraryFlow = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this._collectionFlow = new System.Windows.Forms.FlowLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.pretendLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this._dividerPanel = new System.Windows.Forms.Panel();
			this._settingsProtectionHelper = new Palaso.UI.WindowsForms.SettingProtection.SettingsProtectionHelper(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this._sourcePaneMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._localizationExtender)).BeginInit();
			this._vernacularCollectionMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this._libraryFlow.SuspendLayout();
			this._collectionFlow.SuspendLayout();
			this.SuspendLayout();
			//
			// contextMenuStrip1
			//
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._updateThumbnailMenu,
			this._updateFrontMatterToolStripMenu,
			this._openFolderOnDisk,
			this.toolStripMenuItem2,
			this.deleteMenuItem});
			this._localizationExtender.SetLocalizableToolTip(this.contextMenuStrip1, null);
			this._localizationExtender.SetLocalizationComment(this.contextMenuStrip1, null);
			this._localizationExtender.SetLocalizingId(this.contextMenuStrip1, "contextMenuStrip1.contextMenuStrip1");
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(182, 98);
			//
			// _updateThumbnailMenu
			//
			this._localizationExtender.SetLocalizableToolTip(this._updateThumbnailMenu, null);
			this._localizationExtender.SetLocalizationComment(this._updateThumbnailMenu, null);
			this._localizationExtender.SetLocalizingId(this._updateThumbnailMenu, "._updateThumbnailMenu");
			this._updateThumbnailMenu.Name = "_updateThumbnailMenu";
			this._updateThumbnailMenu.Size = new System.Drawing.Size(181, 22);
			this._updateThumbnailMenu.Text = "Update Thumbnail";
			this._updateThumbnailMenu.ToolTipText = "Did Bloom fail to update the thumbnail you see here? This command makes it try ag" +
	"ain.";
			this._updateThumbnailMenu.Click += new System.EventHandler(this._updateThumbnailMenu_Click);
			//
			// _updateFrontMatterToolStripMenu
			//
			this._localizationExtender.SetLocalizableToolTip(this._updateFrontMatterToolStripMenu, null);
			this._localizationExtender.SetLocalizationComment(this._updateFrontMatterToolStripMenu, null);
			this._localizationExtender.SetLocalizingId(this._updateFrontMatterToolStripMenu, "._updateFrontMatterToolStripMenu");
			this._updateFrontMatterToolStripMenu.Name = "_updateFrontMatterToolStripMenu";
			this._updateFrontMatterToolStripMenu.Size = new System.Drawing.Size(181, 22);
			this._updateFrontMatterToolStripMenu.Text = "Update Book";
			this._updateFrontMatterToolStripMenu.ToolTipText = "New versions of Bloom sometimes can fix or otherwise improve books. This should b" +
	"e safe to do at any time, but is only worth doing if your are instructed to do i" +
	"t by a Bloom specialist.";
			this._updateFrontMatterToolStripMenu.Click += new System.EventHandler(this.OnBringBookUpToDate_Click);
			//
			// _openFolderOnDisk
			//
			this._localizationExtender.SetLocalizableToolTip(this._openFolderOnDisk, null);
			this._localizationExtender.SetLocalizationComment(this._openFolderOnDisk, null);
			this._localizationExtender.SetLocalizingId(this._openFolderOnDisk, "._openFolderOnDisk");
			this._openFolderOnDisk.Name = "_openFolderOnDisk";
			this._openFolderOnDisk.Size = new System.Drawing.Size(181, 22);
			this._openFolderOnDisk.Text = "Open Folder on Disk";
			this._openFolderOnDisk.Click += new System.EventHandler(this._openFolderOnDisk_Click);
			//
			// toolStripMenuItem2
			//
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
			//
			// deleteMenuItem
			//
			this.deleteMenuItem.Image = global::Bloom.Properties.Resources.DeleteMessageBoxButtonImage;
			this._localizationExtender.SetLocalizableToolTip(this.deleteMenuItem, null);
			this._localizationExtender.SetLocalizationComment(this.deleteMenuItem, null);
			this._localizationExtender.SetLocalizingId(this.deleteMenuItem, ".deleteMenuItem");
			this.deleteMenuItem.Name = "deleteMenuItem";
			this.deleteMenuItem.Size = new System.Drawing.Size(181, 22);
			this.deleteMenuItem.Text = "Delete";
			this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
			//
			// _bookThumbnails
			//
			this._bookThumbnails.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_bookThumbnails.ImageStream")));
			this._bookThumbnails.TransparentColor = System.Drawing.Color.Transparent;
			this._bookThumbnails.Images.SetKeyName(0, "booklet70x70.png");
			//
			// toolTip1
			//
			this.toolTip1.AutoPopDelay = 15000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			//
			// _sourcePaneMenuStrip
			//
			this._sourcePaneMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripMenuItem1});
			this._localizationExtender.SetLocalizableToolTip(this._sourcePaneMenuStrip, null);
			this._localizationExtender.SetLocalizationComment(this._sourcePaneMenuStrip, null);
			this._localizationExtender.SetLocalizingId(this._sourcePaneMenuStrip, "contextMenuStrip2.contextMenuStrip2");
			this._sourcePaneMenuStrip.Name = "_sourcePaneMenuStrip";
			this._sourcePaneMenuStrip.Size = new System.Drawing.Size(260, 26);
			//
			// toolStripMenuItem1
			//
			this._localizationExtender.SetLocalizableToolTip(this.toolStripMenuItem1, null);
			this._localizationExtender.SetLocalizationComment(this.toolStripMenuItem1, null);
			this._localizationExtender.SetLocalizingId(this.toolStripMenuItem1, ".toolStripMenuItem1");
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 22);
			this.toolStripMenuItem1.Text = "Open Additional Collections Folder";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.OnOpenAdditionalCollectionsFolderClick);
			//
			// _localizationExtender
			//
			this._localizationExtender.LocalizationManagerId = "Bloom";
			//
			// _vernacularCollectionMenuStrip
			//
			this._vernacularCollectionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._showHistoryMenu,
			this._showNotesMenu,
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem});
			this._localizationExtender.SetLocalizableToolTip(this._vernacularCollectionMenuStrip, null);
			this._localizationExtender.SetLocalizationComment(this._vernacularCollectionMenuStrip, null);
			this._localizationExtender.SetLocalizingId(this._vernacularCollectionMenuStrip, "contextMenuStrip2.contextMenuStrip2");
			this._vernacularCollectionMenuStrip.Name = "_vernacularCollectionMenuStrip";
			this._vernacularCollectionMenuStrip.Size = new System.Drawing.Size(266, 92);
			this._vernacularCollectionMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this._vernacularCollectionMenuStrip_Opening);
			//
			// _showHistoryMenu
			//
			this._localizationExtender.SetLocalizableToolTip(this._showHistoryMenu, null);
			this._localizationExtender.SetLocalizationComment(this._showHistoryMenu, null);
			this._localizationExtender.SetLocalizationPriority(this._showHistoryMenu, Localization.LocalizationPriority.Medium);
			this._localizationExtender.SetLocalizingId(this._showHistoryMenu, ".showHistoryToolStripMenuItem");
			this._showHistoryMenu.Name = "_showHistoryMenu";
			this._showHistoryMenu.Size = new System.Drawing.Size(265, 22);
			this._showHistoryMenu.Text = "Collection History...";
			this._showHistoryMenu.Click += new System.EventHandler(this.OnVernacularProjectHistoryClick);
			//
			// _showNotesMenu
			//
			this._showNotesMenu.Enabled = false;
			this._localizationExtender.SetLocalizableToolTip(this._showNotesMenu, null);
			this._localizationExtender.SetLocalizationComment(this._showNotesMenu, null);
			this._localizationExtender.SetLocalizingId(this._showNotesMenu, ".showNotesToolStripMenuItem");
			this._showNotesMenu.Name = "_showNotesMenu";
			this._showNotesMenu.Size = new System.Drawing.Size(265, 22);
			this._showNotesMenu.Text = "Collection Notes...";
			this._showNotesMenu.Click += new System.EventHandler(this.OnShowNotesMenu);
			//
			// _doChecksAndUpdatesOfAllBooksToolStripMenuItem
			//
			this._localizationExtender.SetLocalizableToolTip(this._doChecksAndUpdatesOfAllBooksToolStripMenuItem, null);
			this._localizationExtender.SetLocalizationComment(this._doChecksAndUpdatesOfAllBooksToolStripMenuItem, null);
			this._localizationExtender.SetLocalizingId(this._doChecksAndUpdatesOfAllBooksToolStripMenuItem, ".doChecksAndUpdatesOfAllBooksToolStripMenuItem");
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem.Name = "_doChecksAndUpdatesOfAllBooksToolStripMenuItem";
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem.Text = "Do Checks and Updates of All Books";
			this._doChecksAndUpdatesOfAllBooksToolStripMenuItem.Click += new System.EventHandler(this._doChecksAndUpdatesOfAllBooksToolStripMenuItem_Click);
			//
			// splitContainer1
			//
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this._localizationExtender.SetLocalizableToolTip(this.splitContainer1, null);
			this._localizationExtender.SetLocalizationComment(this.splitContainer1, null);
			this._localizationExtender.SetLocalizingId(this.splitContainer1, "LibraryListView.splitContainer1");
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			// splitContainer1.Panel1
			//
			this.splitContainer1.Panel1.Controls.Add(this._libraryFlow);
			//
			// splitContainer1.Panel2
			//
			this.splitContainer1.Panel2.Controls.Add(this._collectionFlow);
			this.splitContainer1.Panel2.Controls.Add(this._dividerPanel);
			this.splitContainer1.Size = new System.Drawing.Size(350, 562);
			this.splitContainer1.SplitterDistance = 303;
			this.splitContainer1.SplitterWidth = 10;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			//
			// _libraryFlow
			//
			this._libraryFlow.AutoScroll = true;
			this._libraryFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this._libraryFlow.ContextMenuStrip = this._vernacularCollectionMenuStrip;
			this._libraryFlow.Controls.Add(this.label1);
			this._libraryFlow.Controls.Add(this.label2);
			this._libraryFlow.Controls.Add(this.label3);
			this._libraryFlow.Controls.Add(this.button1);
			this._libraryFlow.Controls.Add(this.button4);
			this._libraryFlow.Controls.Add(this.button5);
			this._libraryFlow.Controls.Add(this.label4);
			this._libraryFlow.Controls.Add(this.label5);
			this._libraryFlow.Controls.Add(this.button6);
			this._libraryFlow.Dock = System.Windows.Forms.DockStyle.Fill;
			this._libraryFlow.Location = new System.Drawing.Point(0, 0);
			this._libraryFlow.Name = "_libraryFlow";
			this._libraryFlow.Size = new System.Drawing.Size(350, 303);
			this._libraryFlow.TabIndex = 0;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._libraryFlow.SetFlowBreak(this.label1, true);
			this._localizationExtender.SetLocalizableToolTip(this.label1, null);
			this._localizationExtender.SetLocalizationComment(this.label1, null);
			this._localizationExtender.SetLocalizingId(this.label1, "LibraryListView.label1");
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 0;
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this._localizationExtender.SetLocalizableToolTip(this.label2, null);
			this._localizationExtender.SetLocalizationComment(this.label2, null);
			this._localizationExtender.SetLocalizingId(this.label2, "LibraryListView.label2");
			this.label2.Location = new System.Drawing.Point(0, 13);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 3;
			//
			// label3
			//
			this.label3.AutoSize = true;
			this._libraryFlow.SetFlowBreak(this.label3, true);
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this._localizationExtender.SetLocalizableToolTip(this.label3, null);
			this._localizationExtender.SetLocalizationComment(this.label3, null);
			this._localizationExtender.SetLocalizationPriority(this.label3, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.label3, "LibraryListView.label3");
			this.label3.Location = new System.Drawing.Point(0, 13);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.label3.Size = new System.Drawing.Size(69, 29);
			this.label3.TabIndex = 6;
			this.label3.Text = "Header";
			//
			// button1
			//
			this.button1.AutoSize = true;
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = global::Bloom.Properties.Resources.edit;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._localizationExtender.SetLocalizableToolTip(this.button1, null);
			this._localizationExtender.SetLocalizationComment(this.button1, null);
			this._localizationExtender.SetLocalizationPriority(this.button1, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.button1, "LibraryListView.button1");
			this.button1.Location = new System.Drawing.Point(3, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(211, 81);
			this.button1.TabIndex = 1;
			this.button1.Text = "The amazing\r\nadventures \r\nof aunt altimony";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button1.UseVisualStyleBackColor = true;
			//
			// button4
			//
			this.button4.AutoSize = true;
			this.button4.Dock = System.Windows.Forms.DockStyle.Top;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Image = global::Bloom.Properties.Resources.edit;
			this._localizationExtender.SetLocalizableToolTip(this.button4, null);
			this._localizationExtender.SetLocalizationComment(this.button4, null);
			this._localizationExtender.SetLocalizationPriority(this.button4, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.button4, "LibraryListView.button4");
			this.button4.Location = new System.Drawing.Point(220, 45);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 57);
			this.button4.TabIndex = 7;
			this.button4.Text = "button4";
			this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button4.UseVisualStyleBackColor = true;
			//
			// button5
			//
			this.button5.AutoSize = true;
			this.button5.Dock = System.Windows.Forms.DockStyle.Top;
			this.button5.FlatAppearance.BorderSize = 0;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._libraryFlow.SetFlowBreak(this.button5, true);
			this.button5.Image = global::Bloom.Properties.Resources.edit;
			this._localizationExtender.SetLocalizableToolTip(this.button5, null);
			this._localizationExtender.SetLocalizationComment(this.button5, null);
			this._localizationExtender.SetLocalizationPriority(this.button5, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.button5, "LibraryListView.button5");
			this.button5.Location = new System.Drawing.Point(3, 132);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 57);
			this.button5.TabIndex = 8;
			this.button5.Text = "button5";
			this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button5.UseVisualStyleBackColor = true;
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.White;
			this._localizationExtender.SetLocalizableToolTip(this.label4, null);
			this._localizationExtender.SetLocalizationComment(this.label4, null);
			this._localizationExtender.SetLocalizingId(this.label4, "LibraryListView.label4");
			this.label4.Location = new System.Drawing.Point(0, 192);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 13);
			this.label4.TabIndex = 9;
			//
			// label5
			//
			this.label5.AutoSize = true;
			this._libraryFlow.SetFlowBreak(this.label5, true);
			this.label5.ForeColor = System.Drawing.Color.White;
			this._localizationExtender.SetLocalizableToolTip(this.label5, null);
			this._localizationExtender.SetLocalizationComment(this.label5, null);
			this._localizationExtender.SetLocalizationPriority(this.label5, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.label5, "LibraryListView.label5");
			this.label5.Location = new System.Drawing.Point(0, 192);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.label5.Size = new System.Drawing.Size(42, 33);
			this.label5.TabIndex = 10;
			this.label5.Text = "Header";
			//
			// button6
			//
			this.button6.AutoSize = true;
			this.button6.Dock = System.Windows.Forms.DockStyle.Top;
			this.button6.FlatAppearance.BorderSize = 0;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._libraryFlow.SetFlowBreak(this.button6, true);
			this.button6.Image = global::Bloom.Properties.Resources.edit;
			this._localizationExtender.SetLocalizableToolTip(this.button6, null);
			this._localizationExtender.SetLocalizationComment(this.button6, null);
			this._localizationExtender.SetLocalizationPriority(this.button6, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.button6, "LibraryListView.button6");
			this.button6.Location = new System.Drawing.Point(3, 228);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(134, 57);
			this.button6.TabIndex = 11;
			this.button6.Text = "rat na pik i painim mango";
			this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button6.UseVisualStyleBackColor = true;
			//
			// _collectionFlow
			//
			this._collectionFlow.AutoScroll = true;
			this._collectionFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this._collectionFlow.ContextMenuStrip = this._sourcePaneMenuStrip;
			this._collectionFlow.Controls.Add(this.label7);
			this._collectionFlow.Controls.Add(this.pretendLabel);
			this._collectionFlow.Controls.Add(this.label9);
			this._collectionFlow.Dock = System.Windows.Forms.DockStyle.Fill;
			this._collectionFlow.Location = new System.Drawing.Point(0, 1);
			this._collectionFlow.Name = "_collectionFlow";
			this._collectionFlow.Size = new System.Drawing.Size(350, 248);
			this._collectionFlow.TabIndex = 0;
			//
			// label7
			//
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.White;
			this._localizationExtender.SetLocalizableToolTip(this.label7, null);
			this._localizationExtender.SetLocalizationComment(this.label7, null);
			this._localizationExtender.SetLocalizingId(this.label7, "LibraryListView.label7");
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(0, 13);
			this.label7.TabIndex = 3;
			//
			// pretendLabel
			//
			this.pretendLabel.AutoSize = true;
			this._collectionFlow.SetFlowBreak(this.pretendLabel, true);
			this.pretendLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pretendLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this._localizationExtender.SetLocalizableToolTip(this.pretendLabel, null);
			this._localizationExtender.SetLocalizationComment(this.pretendLabel, null);
			this._localizationExtender.SetLocalizationPriority(this.pretendLabel, Localization.LocalizationPriority.NotLocalizable);
			this._localizationExtender.SetLocalizingId(this.pretendLabel, "LibraryListView.label8");
			this.pretendLabel.Location = new System.Drawing.Point(0, 0);
			this.pretendLabel.Margin = new System.Windows.Forms.Padding(0);
			this.pretendLabel.Name = "pretendLabel";
			this.pretendLabel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.pretendLabel.Size = new System.Drawing.Size(110, 29);
			this.pretendLabel.TabIndex = 6;
			this.pretendLabel.Text = "Source Books";
			//
			// label9
			//
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.White;
			this._localizationExtender.SetLocalizableToolTip(this.label9, null);
			this._localizationExtender.SetLocalizationComment(this.label9, null);
			this._localizationExtender.SetLocalizingId(this.label9, "LibraryListView.label9");
			this.label9.Location = new System.Drawing.Point(0, 29);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(0, 13);
			this.label9.TabIndex = 9;
			//
			// _dividerPanel
			//
			this._dividerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this._dividerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._dividerPanel.Location = new System.Drawing.Point(0, 0);
			this._dividerPanel.Margin = new System.Windows.Forms.Padding(0);
			this._dividerPanel.Name = "_dividerPanel";
			this._dividerPanel.Size = new System.Drawing.Size(350, 1);
			this._dividerPanel.TabIndex = 6;
			//
			// LibraryListView
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Controls.Add(this.splitContainer1);
			this._localizationExtender.SetLocalizableToolTip(this, null);
			this._localizationExtender.SetLocalizationComment(this, null);
			this._localizationExtender.SetLocalizingId(this, "LibraryListView.LibraryListView");
			this.Name = "LibraryListView";
			this.Size = new System.Drawing.Size(350, 562);
			this.BackColorChanged += new System.EventHandler(this.OnBackColorChanged);
			this.contextMenuStrip1.ResumeLayout(false);
			this._sourcePaneMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._localizationExtender)).EndInit();
			this._vernacularCollectionMenuStrip.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this._libraryFlow.ResumeLayout(false);
			this._libraryFlow.PerformLayout();
			this._collectionFlow.ResumeLayout(false);
			this._collectionFlow.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList _bookThumbnails;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem _updateThumbnailMenu;
		private System.Windows.Forms.ToolStripMenuItem _updateFrontMatterToolStripMenu;
		private System.Windows.Forms.ToolStripMenuItem _openFolderOnDisk;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private Bloom.ToPalaso.BetterSplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel _libraryFlow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.FlowLayoutPanel _collectionFlow;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label pretendLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel _dividerPanel;
		private System.Windows.Forms.Timer _keepFocusTimer;
		private Localization.UI.LocalizationExtender _localizationExtender;
		private Palaso.UI.WindowsForms.SettingProtection.SettingsProtectionHelper _settingsProtectionHelper;
		private System.Windows.Forms.ContextMenuStrip _sourcePaneMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip _vernacularCollectionMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem _showHistoryMenu;
		private System.Windows.Forms.ToolStripMenuItem _showNotesMenu;
		private System.Windows.Forms.ToolStripMenuItem _doChecksAndUpdatesOfAllBooksToolStripMenuItem;
	}
}