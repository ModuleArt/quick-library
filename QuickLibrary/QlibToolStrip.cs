using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolStrip : ToolStrip
	{
		public QlibToolStrip() { }

		public void SetDarkMode(bool dark, bool titlebar)
		{
			if (dark)
			{
				if (titlebar)
				{
					this.BackColor = ThemeManager.DarkMainColor;
				}
				else
				{
					this.BackColor = ThemeManager.DarkBackColor;
				}
			}

			foreach (var c in this.Items)
			{
				if (c.GetType() == typeof(QlibToolStripSeparator))
				{
					(c as QlibToolStripSeparator).SetDarkMode(dark);
				}
				else if (c.GetType() == typeof(ToolStripDropDownButton))
				{
					if (dark)
					{
						(c as ToolStripDropDownButton).DropDown.BackColor = ThemeManager.DarkSecondColor;
						(c as ToolStripDropDownButton).DropDown.ForeColor = Color.White;
					}
					else
					{
						(c as ToolStripDropDownButton).DropDown.BackColor = ThemeManager.LightSecondColor;
						(c as ToolStripDropDownButton).DropDown.ForeColor = Color.Black;
					}

					foreach (var c2 in (c as ToolStripDropDownButton).DropDownItems)
					{
						if (c2.GetType() == typeof(ToolStripMenuItem))
						{
							if (dark)
							{
								(c2 as ToolStripMenuItem).DropDown.BackColor = ThemeManager.DarkSecondColor;
								(c2 as ToolStripMenuItem).DropDown.ForeColor = Color.White;
							}
							else
							{
								(c2 as ToolStripMenuItem).DropDown.BackColor = ThemeManager.LightSecondColor;
								(c2 as ToolStripMenuItem).DropDown.ForeColor = Color.Black;
							}
						}
					}
				}
			}

			this.Renderer = new CustomToolStripSystemRenderer(dark);
		}
	}

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
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkSecondColor), e.Item.Bounds);
					e.Item.BackColor = ThemeManager.DarkSecondColor;
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightSecondColor), e.Item.Bounds);
					e.Item.BackColor = ThemeManager.LightSecondColor;
				}
			}
			else
			{
				Rectangle rc = new Rectangle(1, 0, e.Item.Size.Width - 1, e.Item.Height);
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), rc);
					e.Item.BackColor = ThemeManager.DarkPaleColor;
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), rc);
					e.Item.BackColor = ThemeManager.LightPaleColor;
				}
				e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), 1, 0, rc.Width - 1, rc.Height - 1);
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
				e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), rec);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), rec);
			}
			e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), rec);
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}

				e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
			}
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if ((e.Item as ToolStripButton).Checked || (e.Item as ToolStripButton).Selected)
			{
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
				}

				e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2));
			}
		}
	}
}
