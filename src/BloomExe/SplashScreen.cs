﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bloom
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();
			_versionInfo.Text = Shell.GetVersionInfo();
		}

		public void FadeAndClose()
		{
			_fadeOutTimer.Enabled = true;
		}

		private void _fadeOutTimer_Tick(object sender, EventArgs e)
		{
			if (Opacity <= 0)
			{
				Close();
			}
			Opacity -= 0.20;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}

	public class Splasher
	{
		static SplashScreen _splashForm ;
		static Thread _splashThread;

		static public void Show()
		{
			_splashForm = new SplashScreen();
			Application.Run(_splashForm);
		}

		static public void Hide()
		{
			_splashForm.Hide();
		}


		static public void Close()
		{
			if (_splashThread == null) return;
			if (_splashForm == null) return;

			try
			{
				_splashForm.Invoke(new MethodInvoker(_splashForm.FadeAndClose));
			}
			catch (Exception)
			{
			}
			_splashThread = null;
			_splashForm = null;
		}

//
//        static public string Status
//        {
//            set
//            {
//                if (_splashForm == null)
//                {
//                    return;
//                }
//
//                _splashForm.StatusInfo = value;
//            }
//            get
//            {
//                if (_splashForm == null)
//                {
//                    throw new InvalidOperationException("Splash Form not on screen");
//                }
//                return _splashForm.StatusInfo;
//            }
//        }

	}
}