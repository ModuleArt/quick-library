using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibCheckBox : CheckBox
	{
		// PRIVATE FIELDS

		private bool darkMode = false;
		private string darkText;
		private bool hovered = false;
		private bool pressed = false;

		// HIDDEN PROPS

		[Browsable(false)]
		public new Appearance Appearance => base.Appearance;

		[Browsable(false)]
		public new Color ForeColor => base.ForeColor;

		[Browsable(false)]
		public new Color BackColor => base.BackColor;

		[Browsable(false)]
		public new Image BackgroundImage => base.BackgroundImage;

		[Browsable(false)]
		public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

		[Browsable(false)]
		public new ContentAlignment CheckAlign => base.CheckAlign;

		[Browsable(false)]
		public new Image Image => base.Image;

		[Browsable(false)]
		public new Cursor Cursor => base.Cursor;

		[Browsable(false)]
		public new CheckState CheckState => base.CheckState;

		[Browsable(false)]
		public new FlatButtonAppearance FlatAppearance => base.FlatAppearance;

		[Browsable(false)]
		public new FlatStyle FlatStyle => base.FlatStyle;

		[Browsable(false)]
		public new ContentAlignment ImageAlign => base.ImageAlign;

		[Browsable(false)]
		public new int ImageIndex => base.ImageIndex;

		[Browsable(false)]
		public new string ImageKey => base.ImageKey;

		[Browsable(false)]
		public new Padding Padding => base.Padding;

		[Browsable(false)]
		public new RightToLeft RightToLeft => base.RightToLeft;

		[Browsable(false)]
		public new bool AutoSize => base.AutoSize;

		[Browsable(false)]
		public new DockStyle Dock => base.Dock;

		[Browsable(false)]
		public new Size MinimumSize => base.MinimumSize;

		[Browsable(false)]
		public new Size MaximumSize => base.MaximumSize;

		[Browsable(false)]
		public new bool ThreeState => base.ThreeState;

		[Browsable(false)]
		public new bool AutoCheck => base.AutoCheck;

		// PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		// CONSTRUCTOR

		public QlibCheckBox()
		{
			if (darkMode)
			{
				
			}
		}

		// PRIVATE BODY

		private void CustomCheckBox_MouseUp(object sender, MouseEventArgs e)
		{
			pressed = false;
			Refresh();
		}

		private void CustomCheckBox_MouseDown(object sender, MouseEventArgs e)
		{
			pressed = true;
			Refresh();
		}

		private void CustomCheckBox_MouseLeave(object sender, EventArgs e)
		{
			hovered = false;
			Refresh();
		}

		private void CustomCheckBox_MouseEnter(object sender, EventArgs e)
		{
			hovered = true;
			Refresh();
		}

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;

			if (dark)
			{
				base.BackColor = ThemeManager.DarkBackColor;
				base.ForeColor = Color.White;
				darkText = Text;
				//Text = " ";

				SetStyle(ControlStyles.UserPaint, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);

				MouseEnter += CustomCheckBox_MouseEnter;
				MouseLeave += CustomCheckBox_MouseLeave;
				MouseDown += CustomCheckBox_MouseDown;
				MouseUp += CustomCheckBox_MouseUp;
			}
			else
			{
				base.BackColor = ThemeManager.LightBackColor;
				base.ForeColor = Color.Black;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (darkMode)
			{
				int top = (Height / 2) - 8;

				e.Graphics.Clear(BackColor);

				if (pressed)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.PressedColor), new Rectangle(0, top + 2, 15, 15));
				}
				else
				{
					if (hovered)
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkHoverColor), new Rectangle(0, top + 2, 15, 15));
					}
					else
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkSecondColor), new Rectangle(0, top + 2, 15, 15));
					}
				}

				if (Focused)
				{
					e.Graphics.DrawRectangle(new Pen(ThemeManager.BorderColor, 2), new Rectangle(1, top + 3, 13, 13));
				}

				if (Checked)
				{
					e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

					if (Enabled)
					{
						e.Graphics.DrawLine(new Pen(ForeColor, 2), 2, top + 8, 5, top + 11);
						e.Graphics.DrawLine(new Pen(ForeColor, 2), 5, top + 12, 12, top + 5);
					}
					else
					{
						e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor, 2), 2, top + 8, 5, top + 11);
						e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor, 2), 5, top + 12, 12, top + 5);
					}
				}

				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (Enabled)
				{
					e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 22, top);
				}
				else
				{
					e.Graphics.DrawString(Text, Font, new SolidBrush(ThemeManager.BorderColor), 22, top);
				}
			}
			else
			{
				base.OnPaint(e);
			}
		}
	}
}
