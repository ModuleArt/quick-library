using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolbar : ToolStrip
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;
		private bool alternativeAppearance = false;
		private bool dragForm = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ToolStripGripStyle GripStyle { get { return base.GripStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text { get { return base.Text; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ToolStripTextDirection TextDirection { get { return base.TextDirection; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool UseWaitCursor { get { return base.UseWaitCursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size ImageScalingSize { get { return base.ImageScalingSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AllowDrop { get { return base.AllowDrop; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool Stretch { get { return base.Stretch; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MinimumSize { get { return base.MinimumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MaximumSize { get { return base.MaximumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Margin { get { return base.Margin; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ToolStripLayoutStyle LayoutStyle { get { return base.LayoutStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding GripMargin { get { return base.GripMargin; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		#endregion

		#region PUBLIC PROPS

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

		[Category("Qlib props"), Browsable(true), Description("Drag form")]
		public bool DragForm
		{
			get { return dragForm; }
			set { dragForm = value; }
		}

		#endregion

		#region CONSTRUCTOR

		public QlibToolbar() 
		{
			base.ForeColor = Color.Black;
			base.BackColor = ThemeMan.LightBackColor;
			base.BackgroundImageLayout = ImageLayout.None;
			base.BackgroundImage = null;
			base.Font = ThemeMan.DefaultFont;
			base.GripStyle = ToolStripGripStyle.Hidden;
			base.RightToLeft = RightToLeft.No;
			base.Text = string.Empty;
			base.TextDirection = ToolStripTextDirection.Horizontal;
			base.UseWaitCursor = false;
			base.ImageScalingSize = new Size(16, 16);
			base.AllowDrop = false;
			base.Stretch = false;
			base.MinimumSize = Size.Empty;
			base.MaximumSize = Size.Empty;
			base.Margin = Padding.Empty;
			base.Padding = new Padding(4, 5, 4, 5);
			base.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			base.GripMargin = Padding.Empty;
			base.AutoSize = false;

			MouseDown += QlibToolbar_MouseDown;
		}

		#endregion

		#region PRIVATE BODY

		private void QlibToolbar_MouseDown(object sender, MouseEventArgs e)
		{
			if (dragForm && e.Button == MouseButtons.Left) NativeMan.DragWindow(Parent.Handle);
		}

		private void SetDarkMode(bool dark, bool alternative)
		{
			darkMode = dark;
			alternativeAppearance = alternative;

			if (dark) base.BackColor = alternative ? ThemeMan.DarkMainColor : ThemeMan.DarkBackColor;
			else base.BackColor = alternative ? ThemeMan.LightMainColor : ThemeMan.LightBackColor;

			foreach (var c in Items)
			{
				if (c.GetType() == typeof(QlibToolsep))
				{
					(c as QlibToolsep).DarkMode = dark;
				}
				else if (c.GetType() == typeof(ToolStripDropDownButton))
				{
					if (dark)
					{
						(c as ToolStripDropDownButton).DropDown.BackColor = ThemeMan.DarkSecondColor;
						(c as ToolStripDropDownButton).DropDown.ForeColor = Color.White;
					}
					else
					{
						(c as ToolStripDropDownButton).DropDown.BackColor = ThemeMan.LightSecondColor;
						(c as ToolStripDropDownButton).DropDown.ForeColor = Color.Black;
					}

					foreach (var c2 in (c as ToolStripDropDownButton).DropDownItems)
					{
						if (c2.GetType() == typeof(ToolStripMenuItem))
						{
							if (dark)
							{
								(c2 as ToolStripMenuItem).DropDown.BackColor = ThemeMan.DarkSecondColor;
								(c2 as ToolStripMenuItem).DropDown.ForeColor = Color.White;
							}
							else
							{
								(c2 as ToolStripMenuItem).DropDown.BackColor = ThemeMan.LightSecondColor;
								(c2 as ToolStripMenuItem).DropDown.ForeColor = Color.Black;
							}
						}
					}
				}
			}

			Renderer = new CustomToolStripSystemRenderer(dark);
		}

		#endregion
	}

	#region INTERNAL CLASSES

	internal class CustomToolStripSystemRenderer : ToolStripSystemRenderer
	{
		private bool darkMode = false;

		public CustomToolStripSystemRenderer(bool darkMode)
		{
			this.darkMode = darkMode;
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			if (darkMode)
			{
				e.ArrowColor = Color.White;
			}
			else
			{
				e.ArrowColor = Color.Black;
			}
			base.OnRenderArrow(e);
		}

		//protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		//{
		//	if (darkMode)
		//	{
		//		e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Item.Bounds);
		//	}
		//	else
		//	{
		//		base.OnRenderOverflowButtonBackground(e);
		//	}
		//}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (!e.Item.Selected)
			{
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.DarkSecondColor), e.Item.Bounds);
					e.Item.BackColor = ThemeMan.DarkSecondColor;
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.LightSecondColor), e.Item.Bounds);
					e.Item.BackColor = ThemeMan.LightSecondColor;
				}
			}
			else
			{
				Rectangle rc = new Rectangle(1, 0, e.Item.Size.Width - 1, e.Item.Height);
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.DarkPaleColor), rc);
					e.Item.BackColor = ThemeMan.DarkPaleColor;
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.LightPaleColor), rc);
					e.Item.BackColor = ThemeMan.LightPaleColor;
				}
				e.Graphics.DrawRectangle(new Pen(ThemeMan.AccentColor), 1, 0, rc.Width - 1, rc.Height - 1);
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			base.OnRenderItemText(e);

			if (darkMode)
			{
				e.Item.ForeColor = Color.White;
			}
			else
			{
				e.Item.ForeColor = Color.Black;
			}
		}

		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			Rectangle rec = new Rectangle
			{
				X = 1,
				Y = 0, 
				Width = 23,
				Height = 23
			};
			if (darkMode)
			{
				e.Graphics.FillRectangle(new SolidBrush(ThemeMan.DarkPaleColor), rec);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(ThemeMan.LightPaleColor), rec);
			}
			e.Graphics.DrawRectangle(new Pen(ThemeMan.AccentColor), rec);
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.DarkPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.LightPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}

				e.Graphics.DrawRectangle(new Pen(ThemeMan.AccentColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
			}
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if ((e.Item as ToolStripButton).Checked || (e.Item as ToolStripButton).Selected)
			{
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.DarkPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeMan.LightPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}

				e.Graphics.DrawRectangle(new Pen(ThemeMan.AccentColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
			}
		}
		
	}

	#endregion
}
