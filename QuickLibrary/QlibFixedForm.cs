using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibFixedForm : Form
	{
		// PRIVATE FIELDS

		private bool darkMode = false;
		private bool alternativeAppearance = false;
		private Color customBackColor = Color.White;

		// HIDDEN PROPS

		[Browsable(false)]
		public new FormBorderStyle FormBorderStyle => base.FormBorderStyle;

		[Browsable(false)]
		public new AutoScaleMode AutoScaleMode => base.AutoScaleMode;

		[Browsable(false)]
		public new bool HelpButton => base.HelpButton;

		[Browsable(false)]
		public new bool AutoScroll => base.AutoScroll;

		[Browsable(false)]
		public new Size AutoScrollMargin => base.AutoScrollMargin;

		[Browsable(false)]
		public new Size AutoScrollMinSize => base.AutoScrollMinSize;

		[Browsable(false)]
		public new bool AutoSize => base.AutoSize;

		[Browsable(false)]
		public new AutoSizeMode AutoSizeMode => base.AutoSizeMode;

		[Browsable(false)]
		public new Image BackgroundImage => base.BackgroundImage;

		[Browsable(false)]
		public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

		[Browsable(false)]
		public new Font Font => base.Font;

		[Browsable(false)]
		public new Color ForeColor => base.ForeColor;

		[Browsable(false)]
		public new Color BackColor => base.BackColor;

		[Browsable(false)]
		public new RightToLeft RightToLeft => base.RightToLeft;

		[Browsable(false)]
		public new bool RightToLeftLayout => base.RightToLeftLayout;

		// PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Custom back color")]
		public Color CustomBackColor 
		{
			get { return customBackColor; }
			set 
			{
				customBackColor = value;
				base.BackColor = value;
			}
		}

		[Category("Qlib props"), Browsable(true), Description("Custom back color")]
		public bool CustomBack { get; set; } = false;

		[Category("Qlib props"), Browsable(true), Description("Draggable form")]
		public bool Draggable { get; set; } = false;

		[Category("Qlib props"), Browsable(true), Description("Title label")]
		public Label TitleLabel { get; set; } = null;

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value, alternativeAppearance); }
		}

		[Category("Qlib props"), Browsable(true), Description("Alternative appearance")]

		public bool AlternativeAppearance
		{
			get { return alternativeAppearance; }
			set { SetDarkMode(darkMode, value); }
		}

		// CONSTRUCTOR

		public QlibFixedForm() 
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.AutoScaleMode = AutoScaleMode.Dpi;
			base.HelpButton = false;
			base.AutoScroll = false;
			base.AutoScrollMargin = new Size(0, 0);
			base.AutoScrollMinSize = new Size(0, 0);
			base.AutoSize = false;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.Font = ThemeManager.DefaultFont;

			TextChanged += QlibFixedForm_TextChanged;
		}

		// PRIVATE BODY

		protected override void OnHandleCreated(EventArgs e)
		{
			(new DropShadow()).ApplyShadows(this);
			base.OnHandleCreated(e);
		}

		private void QlibFixedForm_TextChanged(object sender, EventArgs e)
		{
			if (TitleLabel != null) 
			{
				TitleLabel.Text = Text;
			}
		}

		public void SetDraggableControls(List<Control> controls)
		{
			foreach (Control control in controls)
			{
				control.MouseDown += Control_MouseDown;
			}
		}

		private void Control_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				GoDrag();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button == MouseButtons.Left && Draggable)
			{
				GoDrag();
			}
		}

		private void GoDrag()
		{
			Cursor.Current = Cursors.SizeAll;
			NativeMethodsManager.ReleaseCapture();
			NativeMethodsManager.SendMessage(Handle, 0xA1, 0x2, 0);
		}

		private void SetDarkMode(bool dark, bool alternative)
		{
			darkMode = dark;
			alternativeAppearance = alternative;

			if (dark)
			{
				base.ForeColor = Color.White;

				if (CustomBack)
				{
					base.BackColor = customBackColor;
				}
				else if (alternative)
				{
					base.BackColor = ThemeManager.DarkMainColor;
				}
				else
				{
					base.BackColor = ThemeManager.DarkBackColor;
				}
			}
			else
			{
				base.ForeColor = Color.Black;

				if (CustomBack)
				{
					base.BackColor = customBackColor;
				}
				else if (alternative)
				{
					base.BackColor = ThemeManager.LightMainColor;
				}
				else
				{
					base.BackColor = ThemeManager.LightBackColor;
				}
			}
		}
	}
}
