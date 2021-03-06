﻿using Bloom.Properties;

namespace Bloom
{
	partial class ConfirmRecycleDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
			this._messageLabel = new System.Windows.Forms.Label();
			this.pictureRecycleBin = new System.Windows.Forms.PictureBox();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.deleteBtn = new System.Windows.Forms.Button();
			this._L10NSharpExtender = new L10NSharp.UI.L10NSharpExtender(this.components);
			this.tableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureRecycleBin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._L10NSharpExtender)).BeginInit();
			this.SuspendLayout();
			//
			// tableLayout
			//
			this.tableLayout.AutoSize = true;
			this.tableLayout.BackColor = System.Drawing.Color.Transparent;
			this.tableLayout.ColumnCount = 3;
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayout.Controls.Add(this._messageLabel, 1, 0);
			this.tableLayout.Controls.Add(this.pictureRecycleBin, 0, 0);
			this.tableLayout.Controls.Add(this.cancelBtn, 2, 1);
			this.tableLayout.Controls.Add(this.deleteBtn, 1, 1);
			this.tableLayout.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayout.Location = new System.Drawing.Point(20, 20);
			this.tableLayout.Name = "tableLayout";
			this.tableLayout.RowCount = 2;
			this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayout.Size = new System.Drawing.Size(363, 138);
			this.tableLayout.TabIndex = 1;
			this.tableLayout.SizeChanged += new System.EventHandler(this.HandleTableLayoutSizeChanged);
			//
			// _messageLabel
			//
			this._messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this._messageLabel.AutoSize = true;
			this.tableLayout.SetColumnSpan(this._messageLabel, 2);
			this._L10NSharpExtender.SetLocalizableToolTip(this._messageLabel, null);
			this._L10NSharpExtender.SetLocalizationComment(this._messageLabel, "In your translation, put the {0} placeholder where you want the name of the thing" +
		" to be deleted to appear.");
			this._L10NSharpExtender.SetLocalizingId(this._messageLabel, "ConfirmRecycleDialog._messageLabel");
			this._messageLabel.Location = new System.Drawing.Point(122, 4);
			this._messageLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 10);
			this._messageLabel.Name = "_messageLabel";
			this._messageLabel.Size = new System.Drawing.Size(241, 13);
			this._messageLabel.TabIndex = 2;
			this._messageLabel.Text = "{0} will be moved to the Recycle Bin.";
			//
			// pictureRecycleBin
			//
			this.pictureRecycleBin.Image = global::Bloom.Properties.Resources.RecycleBin;
			this._L10NSharpExtender.SetLocalizableToolTip(this.pictureRecycleBin, null);
			this._L10NSharpExtender.SetLocalizationComment(this.pictureRecycleBin, null);
			this._L10NSharpExtender.SetLocalizingId(this.pictureRecycleBin, "ConfirmRecycleDialog.pictureRecycleBin");
			this.pictureRecycleBin.Location = new System.Drawing.Point(0, 0);
			this.pictureRecycleBin.Margin = new System.Windows.Forms.Padding(0, 0, 20, 10);
			this.pictureRecycleBin.Name = "pictureRecycleBin";
			this.pictureRecycleBin.Size = new System.Drawing.Size(102, 102);
			this.pictureRecycleBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureRecycleBin.TabIndex = 1;
			this.pictureRecycleBin.TabStop = false;
			//
			// cancelBtn
			//
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.AutoSize = true;
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._L10NSharpExtender.SetLocalizableToolTip(this.cancelBtn, null);
			this._L10NSharpExtender.SetLocalizationComment(this.cancelBtn, null);
			this._L10NSharpExtender.SetLocalizingId(this.cancelBtn, "Common.CancelButton");
			this.cancelBtn.Location = new System.Drawing.Point(288, 112);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 26);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "&Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			//
			// deleteBtn
			//
			this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteBtn.AutoSize = true;
			this.deleteBtn.Image = global::Bloom.Properties.Resources.DeleteMessageBoxButtonImage;
			this._L10NSharpExtender.SetLocalizableToolTip(this.deleteBtn, null);
			this._L10NSharpExtender.SetLocalizationComment(this.deleteBtn, null);
			this._L10NSharpExtender.SetLocalizingId(this.deleteBtn, "ConfirmRecycleDialog.deleteBtn");
			this.deleteBtn.Location = new System.Drawing.Point(205, 112);
			this.deleteBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(75, 26);
			this.deleteBtn.TabIndex = 0;
			this.deleteBtn.Text = "&Delete";
			this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
			//
			// _L10NSharpExtender
			//
			this._L10NSharpExtender.LocalizationManagerId = "Bloom";
			//
			// ConfirmRecycleDialog
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(398, 179);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this._L10NSharpExtender.SetLocalizableToolTip(this, null);
			this._L10NSharpExtender.SetLocalizationComment(this, null);
			this._L10NSharpExtender.SetLocalizingId(this, "ConfirmRecycleDialog.ConfirmRecycleWindowTitle");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 28);
			this.Name = "ConfirmRecycleDialog";
			this.Padding = new System.Windows.Forms.Padding(20, 20, 15, 15);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Confirm Delete";
			this.tableLayout.ResumeLayout(false);
			this.tableLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureRecycleBin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._L10NSharpExtender)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayout;
		private System.Windows.Forms.Label _messageLabel;
		private System.Windows.Forms.PictureBox pictureRecycleBin;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button deleteBtn;
		private L10NSharp.UI.L10NSharpExtender _L10NSharpExtender;
	}
}