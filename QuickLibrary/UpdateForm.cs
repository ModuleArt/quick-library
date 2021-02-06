using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public partial class UpdateForm : QlibFixedForm
	{
		private bool _loadednotes;

		public UpdateForm(bool darkMode, string title, string message, string dwnldBtnText, string whatsNewBtnText)
		{
			if (darkMode)
			{
				HandleCreated += new EventHandler(ThemeMan.formHandleCreated);
			}

			InitializeComponent();
			(new DropShadow()).ApplyShadows(this);
			SetDraggableControls(new List<Control>() { titlePanel, titleLabel });

			Height = 160;

			titleLabel.Text = title;
			boxReleaseNotes.Text = whatsNewBtnText;
			messageTextBox.Text = string.Format(message, UpdateChecker.LatestRelease.TagName, "v" + UpdateChecker.CurrentVersion);
			buttonYes.Text = dwnldBtnText;

			infoTooltip.SetToolTip(closeBtn, NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCLOSE) + " | Alt+F4");

			DarkMode = darkMode;
			closeBtn.DarkMode = darkMode;
			if (darkMode)
			{
				buttonYes.BackColor = ThemeMan.DarkSecondColor;
				boxReleaseNotes.BackColor = ThemeMan.DarkSecondColor;
				messageTextBox.BackColor = ThemeMan.DarkBackColor;
				messageTextBox.ForeColor = Color.White;
			}
		}

		async void boxReleaseNotes_CheckedChanged(object sender, EventArgs e)
		{
			if (boxReleaseNotes.Checked)
			{
				Height = 360;
			}
			else
			{
				Height = 160;
			}

			ReleaseNotes.Visible = boxReleaseNotes.Checked;

			if (_loadednotes) return;

			ReleaseNotes.DocumentText = await UpdateChecker.RenderReleaseNotes();
			_loadednotes = true;
		}

		private void UpdateForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void closeBtn_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}