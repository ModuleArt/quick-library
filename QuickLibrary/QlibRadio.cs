using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibRadio : RadioButton
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;
		private bool hovered = false;
		private bool pressed = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Appearance Appearance { get { return base.Appearance; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ContentAlignment CheckAlign { get { return base.CheckAlign; } set {  } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image Image { get { return base.Image; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Cursor Cursor { get { return base.Cursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new FlatStyle FlatStyle { get { return base.FlatStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ContentAlignment ImageAlign { get { return base.ImageAlign; } set {  } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new int ImageIndex { get { return base.ImageIndex; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new string ImageKey { get { return base.ImageKey; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new DockStyle Dock { get { return base.Dock; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MinimumSize { get { return base.MinimumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MaximumSize{ get { return base.MaximumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoCheck { get { return base.AutoCheck; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		#endregion

		#region CONSTRUCTOR

		public QlibRadio()
		{
			base.MaximumSize = DefaultMaximumSize;
			base.MinimumSize = DefaultMinimumSize;
			base.AutoCheck = true;
			base.Dock = DockStyle.None;
			base.AutoSize = false;
			base.RightToLeft = RightToLeft.No;
			base.Padding = Padding.Empty;
			base.ImageKey = null;
			base.ImageIndex = 0;
			base.ImageAlign = ContentAlignment.MiddleCenter;
			base.FlatStyle = FlatStyle.System;
			base.Cursor = Cursors.Default;
			base.Image = null;
			base.BackgroundImageLayout = ImageLayout.None;
			base.BackgroundImage = null;
			base.CheckAlign = ContentAlignment.MiddleLeft;
			base.BackColor = ThemeMan.LightBackColor;
			base.ForeColor = Color.Black;
			base.Appearance = Appearance.Normal;
		}

		#endregion

		#region PRIVATE BODY

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
				base.BackColor = ThemeMan.DarkBackColor;
				base.ForeColor = Color.White;

				SetStyle(ControlStyles.UserPaint, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);

				MouseEnter += CustomCheckBox_MouseEnter;
				MouseLeave += CustomCheckBox_MouseLeave;
				MouseDown += CustomCheckBox_MouseDown;
				MouseUp += CustomCheckBox_MouseUp;
			}
			else
			{
				base.BackColor = ThemeMan.LightBackColor;
				base.ForeColor = Color.Black;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (darkMode)
			{
				int top = (Height / 2) - 9;

				e.Graphics.Clear(BackColor);

				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

				if (pressed)
				{
					e.Graphics.FillEllipse(new SolidBrush(ThemeMan.PressedColor), new Rectangle(0, top + 2, 15, 15));
				}
				else
				{
					if (hovered)
					{
						e.Graphics.FillEllipse(new SolidBrush(ThemeMan.DarkHoverColor), new Rectangle(0, top + 2, 15, 15));
					}
					else
					{
						e.Graphics.FillEllipse(new SolidBrush(ThemeMan.DarkSecondColor), new Rectangle(0, top + 2, 15, 15));
					}
				}

				if (Focused)
				{
					e.Graphics.DrawEllipse(new Pen(ThemeMan.BorderColor, 2), new Rectangle(1, top + 3, 13, 13));
				}

				if (Checked)
				{
					if (Enabled)
					{
						e.Graphics.FillEllipse(new SolidBrush(ForeColor), new Rectangle(4, top + 6, 7, 7));
					}
					else
					{
						e.Graphics.FillEllipse(new SolidBrush(ThemeMan.BorderColor), new Rectangle(4, top + 6, 7, 7));
					}
				}

				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (Enabled)
				{
					e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 22, top);
				}
				else
				{
					e.Graphics.DrawString(Text, Font, new SolidBrush(ThemeMan.BorderColor), 22, top);
				}
			}
			else
			{
				base.OnPaint(e);
			}
		}

		#endregion
	}
}