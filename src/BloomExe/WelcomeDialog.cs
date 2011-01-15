﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bloom.ToPalaso;
using Palaso.IO;

namespace Bloom
{
	public partial class WelcomeDialog : Form
	{
		public WelcomeDialog(MostRecentPathsList mruLibraryPaths)
		{
			InitializeComponent();
			_welcomeControl.TemplateLabel.ForeColor = Color.FromArgb(0x61, 0x94, 0x38);//0xa0, 0x3c, 0x50);
			_welcomeControl.TemplateButton.Image = this.Icon.ToBitmap();
			_welcomeControl.TemplateButton.Image.Tag = "testfrombloom";
			_welcomeControl.Init(mruLibraryPaths, DefaultParentDirectoryForProjects(),
				"Create new library",
				"Browse for other libraries on this computer...",
				dir=>true,
				CreateNewProject);

			_welcomeControl.DoneChoosingOrCreatingProject += (x, y) =>
																{
																	DialogResult = DialogResult.OK;
																	Close();
																};
		}

		private string DefaultParentDirectoryForProjects()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Bloom");
		}

		private string CreateNewProject()
		{
			ChooseNewProjectLocationDialog dlg = new ChooseNewProjectLocationDialog(DefaultParentDirectoryForProjects());
			if (DialogResult.OK != dlg.ShowDialog() || string.IsNullOrEmpty(dlg.PathToNewProjectDirectory))
			{
				return null;
			}
			Directory.CreateDirectory(dlg.PathToNewProjectDirectory);
			return dlg.PathToNewProjectDirectory;
		}

		public string SelectedPath
		{
			get { return _welcomeControl.SelectedPath; }
		}

	}
}