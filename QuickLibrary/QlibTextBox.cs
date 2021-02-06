using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary 
{
	public class QlibTextBox : Panel
	{
		#region PRIVATE FIELDS

		private TextBox textBox;
		private bool darkMode = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Cursor Cursor { get { return base.Cursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoScroll { get { return base.AutoScroll; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new AutoSizeMode AutoSizeMode { get { return base.AutoSizeMode; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		#endregion

		#region PUBLIC PROPS

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

		#endregion

		#region CONSTRUCTOR

		public QlibTextBox()
		{
			base.BackgroundImageLayout = ImageLayout.None;
			base.BackgroundImage = null;
			base.Cursor = Cursors.IBeam;
			base.BackColor = ThemeMan.LightBackColor;
			base.ForeColor = Color.Black;
			base.BorderStyle = BorderStyle.None;
			base.Font = ThemeMan.DefaultFont;
			base.AutoScroll = false;
			base.AutoSize = false;
			base.AutoSizeMode = AutoSizeMode;
			base.RightToLeft = RightToLeft.No;
			base.Padding = Padding.Empty;

			textBox = new TextBox();

			textBox.Location = new Point(7, 7);
			textBox.BorderStyle = BorderStyle.None;
			textBox.BackColor = BackColor;

			textBox.TextChanged += TextBox_TextChanged;

			Controls.Add(textBox);

			SizeChanged += QlibTextBox_SizeChanged;
			GotFocus += QlibTextBox_GotFocus;
			Click += QlibTextBox_Click;
		}

		#endregion

		#region PRIVATE BODY

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
				base.BackColor = ThemeMan.DarkSecondColor;
				textBox.ForeColor = Color.White;
			}
			else
			{
				base.BackColor = ThemeMan.LightSecondColor;
				textBox.ForeColor = Color.Black;
			}
			textBox.BackColor = BackColor;
		}

		#endregion
	}
}
