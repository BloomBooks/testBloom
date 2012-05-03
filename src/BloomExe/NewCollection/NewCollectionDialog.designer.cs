namespace Bloom.NewCollection
{
	partial class NewCollectionDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		protected readonly System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCollectionDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this._textLibraryName = new System.Windows.Forms.TextBox();
			this._pathLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._chooseLanguageButton = new System.Windows.Forms.Button();
			this._languageInfoLabel = new Palaso.UI.WindowsForms.Widgets.BetterLabel();
			this._kindOfCollectionControl1 = new KindOfCollectionControl();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "What would you like to call this collection?";
			//
			// btnOK
			//
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(273, 281);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(91, 29);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			//
			// btnCancel
			//
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(383, 281);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 27);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// _textLibraryName
			//
			this._textLibraryName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._textLibraryName.Location = new System.Drawing.Point(28, 137);
			this._textLibraryName.Name = "_textLibraryName";
			this._textLibraryName.Size = new System.Drawing.Size(146, 23);
			this._textLibraryName.TabIndex = 1;
			this._textLibraryName.TextChanged += new System.EventHandler(this._textLibraryName_TextChanged);
			//
			// _pathLabel
			//
			this._pathLabel.AutoSize = true;
			this._pathLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._pathLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
			this._pathLabel.Location = new System.Drawing.Point(29, 163);
			this._pathLabel.Name = "_pathLabel";
			this._pathLabel.Size = new System.Drawing.Size(52, 15);
			this._pathLabel.TabIndex = 4;
			this._pathLabel.Text = "pathInfo";
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(25, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(267, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "What language are you going to make books for?";
			//
			// _chooseLanguageButton
			//
			this._chooseLanguageButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._chooseLanguageButton.Location = new System.Drawing.Point(28, 58);
			this._chooseLanguageButton.Name = "_chooseLanguageButton";
			this._chooseLanguageButton.Size = new System.Drawing.Size(122, 23);
			this._chooseLanguageButton.TabIndex = 0;
			this._chooseLanguageButton.Text = "Choose &Language...";
			this._chooseLanguageButton.UseVisualStyleBackColor = true;
			this._chooseLanguageButton.Click += new System.EventHandler(this._chooseLanguageButton_Click);
			//
			// _languageInfoLabel
			//
			this._languageInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this._languageInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._languageInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._languageInfoLabel.Location = new System.Drawing.Point(168, 57);
			this._languageInfoLabel.Multiline = true;
			this._languageInfoLabel.Name = "_languageInfoLabel";
			this._languageInfoLabel.ReadOnly = true;
			this._languageInfoLabel.Size = new System.Drawing.Size(303, 24);
			this._languageInfoLabel.TabIndex = 8;
			this._languageInfoLabel.TabStop = false;
			//
			// _kindOfCollectionControl1
			//
			this._kindOfCollectionControl1.Location = new System.Drawing.Point(339, 18);
			this._kindOfCollectionControl1.Name = "_kindOfCollectionControl1";
			this._kindOfCollectionControl1.Size = new System.Drawing.Size(140, 292);
			this._kindOfCollectionControl1.TabIndex = 9;
			//
			// NewCollectionDialog
			//
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(491, 320);
			this.Controls.Add(this._kindOfCollectionControl1);
			this.Controls.Add(this._languageInfoLabel);
			this.Controls.Add(this._chooseLanguageButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._pathLabel);
			this.Controls.Add(this._textLibraryName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewCollectionDialog";
			this.Text = "New Collection";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.Button btnCancel;
		protected System.Windows.Forms.TextBox _textLibraryName;
		protected System.Windows.Forms.Label _pathLabel;
		protected System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button _chooseLanguageButton;
		private Palaso.UI.WindowsForms.Widgets.BetterLabel _languageInfoLabel;
		private KindOfCollectionControl _kindOfCollectionControl1;
	}
}