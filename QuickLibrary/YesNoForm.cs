using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public partial class YesNoForm : QlibFixedForm
	{
		public YesNoForm(
			string messageText,
			string yesBtnText,
			Image yesBtnImage,
			bool showNoBtn,
			string noBtnText,
			Image noBtnImage,
			string windowTitle,
			bool darkMode = false
		)
		{
			if (darkMode)
			{
				HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
			}

			InitializeComponent();
			(new DropShadow()).ApplyShadows(this);
			SetDraggableControls(new List<Control>() { titleLabel });

			if (yesBtnText.Length == 0)
			{
				yesBtn.Text = NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDYES);
			}
			else
			{
				yesBtn.Text = yesBtnText;
			}
			if (yesBtnImage != null)
			{
				yesBtn.Image = yesBtnImage;
				yesBtn.TextAlign = ContentAlignment.MiddleRight;
				yesBtn.Text = " " + yesBtn.Text;
			}

			if (noBtnText.Length == 0)
			{
				noBtn.Text = NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDNO);
			}
			else
			{
				noBtn.Text = noBtnText;
			}
			if (noBtnImage != null)
			{
				noBtn.Image = noBtnImage;
				noBtn.TextAlign = ContentAlignment.MiddleRight;
				noBtn.Text = " " + noBtn.Text;
			}

			Text = windowTitle;
			cancelBtn.Text = NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCANCEL);

			textBox.BackColor = BackColor;
			textBox.Text = messageText;

			if (showNoBtn)
			{
				noBtn.Visible = true;
			}
			else
			{
				Size = new Size(Size.Width, Size.Height - noBtn.Height - 10);
			}

			infoTooltip.SetToolTip(closeBtn, NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCLOSE) + " | Alt+F4");

			DarkMode = darkMode;
			closeBtn.DarkMode = darkMode;
			if (darkMode)
			{
				yesBtn.BackColor = ThemeManager.DarkSecondColor;
				noBtn.BackColor = ThemeManager.DarkSecondColor;
				cancelBtn.BackColor = ThemeManager.DarkSecondColor;
				textBox.ForeColor = Color.White;
			}
		}

		private void YesNoForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void yesBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
		}

		private void noBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}