using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	internal partial class YesNoForm : QlibFixedForm
	{
		internal YesNoForm(
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
			InitializeComponent();
			(new DropShadow()).ApplyShadows(this);
			SetDraggableControls(new List<Control>() { titleLabel });

			yesBtn.Text = yesBtnText.Length == 0 ? NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDYES) : yesBtnText;
			if (yesBtnImage != null)
			{
				yesBtn.Image = yesBtnImage;
				yesBtn.TextAlign = ContentAlignment.MiddleRight;
				yesBtn.Text = " " + yesBtn.Text;
			}

			noBtn.Text = noBtnText.Length == 0 ? NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDNO) : noBtnText;
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

			if (showNoBtn) noBtn.Visible = true;
			else Size = new Size(Size.Width, Size.Height - noBtn.Height - 10);

			infoTooltip.SetToolTip(closeBtn, NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCLOSE) + " | Alt+F4");

			DarkMode = darkMode;
			closeBtn.DarkMode = darkMode;
			if (darkMode)
			{
				yesBtn.BackColor = ThemeMan.DarkSecondColor;
				noBtn.BackColor = ThemeMan.DarkSecondColor;
				cancelBtn.BackColor = ThemeMan.DarkSecondColor;
				textBox.ForeColor = Color.White;
				textBox.BackColor = ThemeMan.DarkBackColor;
			}
		}

		private void YesNoForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) Close();
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