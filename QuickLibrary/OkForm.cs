using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	internal partial class OkForm : QlibFixedForm
	{
		public OkForm(string messageText, string windowTitle, bool darkMode = false)
		{
			InitializeComponent();
			(new DropShadow()).ApplyShadows(this);
			SetDraggableControls(new List<Control>() { titleLabel });

			Text = windowTitle;
			okBtn.Text = NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDOK);

			textBox.BackColor = BackColor;
			textBox.Text = messageText;

			infoTooltip.SetToolTip(closeBtn, NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCLOSE) + " | Alt+F4");

			DarkMode = darkMode;
			closeBtn.DarkMode = darkMode;
			if (darkMode)
			{
				okBtn.BackColor = ThemeMan.DarkSecondColor;
				textBox.ForeColor = Color.White;
				textBox.BackColor = ThemeMan.DarkBackColor;
			}
		}

		private void OkForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}