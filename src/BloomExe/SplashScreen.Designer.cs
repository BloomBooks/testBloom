﻿namespace Bloom
{
	partial class SplashScreen
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this._fadeOutTimer = new System.Windows.Forms.Timer(this.components);
			this._versionInfo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			//
			// pictureBox1
			//
			this.pictureBox1.Image = global::Bloom.Properties.Resources.Logo217x79;
			this.pictureBox1.Location = new System.Drawing.Point(16, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(520, 79);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(87, 163);
			this.label1.MaximumSize = new System.Drawing.Size(400, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 72);
			this.label1.TabIndex = 1;
			this.label1.Text = "This is an Alpha (developmental) version of Bloom. It should not be used for evaluation " +
	"or training.  Please wait for a Beta version.";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			//
			// _fadeOutTimer
			//
			this._fadeOutTimer.Tick += new System.EventHandler(this._fadeOutTimer_Tick);
			//
			// _versionInfo
			//
			this._versionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._versionInfo.AutoSize = true;
			this._versionInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this._versionInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._versionInfo.Location = new System.Drawing.Point(13, 287);
			this._versionInfo.Name = "_versionInfo";
			this._versionInfo.Size = new System.Drawing.Size(70, 13);
			this._versionInfo.TabIndex = 13;
			this._versionInfo.Text = "Version Info";
			//
			// label2
			//
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Maroon;
			this.label2.Location = new System.Drawing.Point(320, 286);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(183, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "<-- Will expire 30 days after build date";
			//
			// pictureBox2
			//
			this.pictureBox2.Image = global::Bloom.Properties.Resources.construction;
			this.pictureBox2.Location = new System.Drawing.Point(12, 163);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(69, 71);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			//
			// SplashScreen
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(548, 309);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._versionInfo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.Name = "SplashScreen";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashScreen";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer _fadeOutTimer;
		private System.Windows.Forms.Label _versionInfo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}