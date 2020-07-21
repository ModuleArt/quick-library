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
