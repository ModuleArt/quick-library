﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public partial class UpdateForm : QlibFixedForm
	{
		private readonly UpdateChecker _checker;
		private bool _loadednotes;

		public UpdateForm(UpdateChecker checker, string appName, bool darkMode)
		{
			if (darkMode)
			{
				this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
			}

			_checker = checker;

			InitializeComponent();
			(new DropShadow()).ApplyShadows(this);
			SetDraggableControls(new List<Control>() { titlePanel, titleLabel, label1, label2, currentLabel, latestLabel });

			this.Height = 200;

			label1.Text = string.Format(label1.Text, appName);

			currentVersionLink.Text = "v" + _checker.CurrentVersion;
			latestReleaseLink.Text = _checker.LatestRelease.TagName;

			if (darkMode)
			{
				this.BackColor = ThemeManager.DarkBackColor;
				this.ForeColor = Color.White;

				buttonYes.BackColor = ThemeManager.DarkSecondColor;
				boxReleaseNotes.BackColor = ThemeManager.DarkSecondColor;
			}

			currentVersionLink.LinkColor = ThemeManager.AccentColor;
			latestReleaseLink.LinkColor = ThemeManager.AccentColor;
			closeBtn.SetDarkMode(darkMode);
		}

		async void boxReleaseNotes_CheckedChanged(object sender, EventArgs e)
		{
			if (boxReleaseNotes.Checked)
			{
				this.Height = 400;
			}
			else
			{
				this.Height = 200;
			}

			ReleaseNotes.Visible = boxReleaseNotes.Checked;

			if (_loadednotes) return;

			ReleaseNotes.DocumentText = await _checker.RenderReleaseNotes();
			_loadednotes = true;
		}

		private void UpdateForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void latestReleaseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = "https://github.com/" + _checker.RepositoryOwner + "/" + _checker.RepostoryName + "/releases/tag/" + _checker.LatestRelease.TagName;
			Process.Start(url);
		}

		private void currentVersionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = "https://github.com/" + _checker.RepositoryOwner + "/" + _checker.RepostoryName + "/releases/tag/v" + _checker.CurrentVersion;
			Process.Start(url);
		}

		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}