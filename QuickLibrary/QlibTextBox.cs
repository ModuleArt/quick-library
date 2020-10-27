using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary 
{
	public class QlibTextBox : Panel
	{
		// PRIVATE FIELDS

		private TextBox textBox;
		private bool darkMode = false;

		// HIDDEN PROPS

		[Browsable(false)]
		public new Image BackgroundImage => base.BackgroundImage;

		[Browsable(false)]
		public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

		[Browsable(false)]
		public new Color ForeColor => base.ForeColor;

		[Browsable(false)]
		public new Color BackColor => base.BackColor;

		[Browsable(false)]
		public new Cursor Cursor => base.Cursor;

		[Browsable(false)]
		public new BorderStyle BorderStyle => base.BorderStyle;

		[Browsable(false)]
		public new Font Font => base.Font;

		[Browsable(false)]
		public new bool AutoScroll => base.AutoScroll;

		[Browsable(false)]
		public new bool AutoSize => base.AutoSize;

		[Browsable(false)]
		public new AutoSizeMode AutoSizeMode => base.AutoSizeMode;

		[Browsable(false)]
		public new Padding Padding => base.Padding;

		[Browsable(false)]
		public new RightToLeft RightToLeft => base.RightToLeft;

		// PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Read only")]
		public bool ReadOnly
		{
			get { return textBox.ReadOnly; }
			set { textBox.ReadOnly = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Word wrap")]
		public bool WordWrap
		{
			get { return textBox.WordWrap; }
			set { textBox.WordWrap = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Text")]
		public override string Text
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		// CONSTRUCTOR

		public QlibTextBox()
		{
			textBox = new TextBox();

			textBox.Location = new Point(7, 7);
			textBox.BorderStyle = BorderStyle.None;
			textBox.BackColor = BackColor;

			textBox.TextChanged += TextBox_TextChanged;

			Controls.Add(textBox);

			base.Cursor = Cursors.IBeam;

			SizeChanged += QlibTextBox_SizeChanged;
			GotFocus += QlibTextBox_GotFocus;
			Click += QlibTextBox_Click;
		}

		// PRIVATE BODY

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			OnTextChanged(e);
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

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;

			if (dark)
			{
				base.BackColor = ThemeManager.DarkSecondColor;
				textBox.ForeColor = Color.White;
			}
			else
			{
				base.BackColor = ThemeManager.LightSecondColor;
				textBox.ForeColor = Color.Black;
			}
			textBox.BackColor = BackColor;
		}
	}
}
