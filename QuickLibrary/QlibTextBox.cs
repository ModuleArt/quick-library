using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary 
{
	public class QlibTextBox : Panel
	{
		public TextBox textBox;

		[Category("Qlib Options"), Browsable(true), Description("Read only")]
		public bool ReadOnly
		{
			get { return textBox.ReadOnly; }
			set { textBox.ReadOnly = value; }
		}

		[Category("Qlib Options"), Browsable(true), Description("Word wrap")]
		public bool WordWrap
		{
			get { return textBox.WordWrap; }
			set { textBox.WordWrap = value; }
		}

		[Category("Qlib Options"), Browsable(true), Description("Text")]
		public override string Text
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		public QlibTextBox()
		{
			textBox = new TextBox();

			textBox.Location = new Point(7, 7);
			textBox.BorderStyle = BorderStyle.None;
			textBox.BackColor = BackColor;

			Controls.Add(textBox);

			this.Cursor = Cursors.IBeam;

			this.SizeChanged += QlibTextBox_SizeChanged;
			this.GotFocus += QlibTextBox_GotFocus;
			this.Click += QlibTextBox_Click;
		}

		private void QlibTextBox_Click(object sender, EventArgs e)
		{
			textBox.Select();
		}

		private void QlibTextBox_GotFocus(object sender, EventArgs e)
		{
			textBox.Focus();
		}

		private void QlibTextBox_SizeChanged(object sender, EventArgs e)
		{
			textBox.Size = new Size(Size.Width - 14, textBox.Size.Height);
		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				BackColor = ThemeManager.DarkSecondColor;
				textBox.ForeColor = Color.White;
			}
			else
			{
				BackColor = ThemeManager.LightSecondColor;
				textBox.ForeColor = Color.Black;
			}
			textBox.BackColor = BackColor;
		}
	}
}
