using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolStrip : ToolStrip
	{
		public QlibToolStrip()
		{
			//this.Paint += QlibToolStrip_Paint;
		}

		//private void QlibToolStrip_Paint(object sender, PaintEventArgs e)
		//{
		//	foreach (var item in this.Items)
		//	{
		//		var asComboBox = item as ToolStripComboBox;
		//		if (asComboBox != null)
		//		{
		//			var location = asComboBox.ComboBox.Location;
		//			var size = asComboBox.ComboBox.Size;
		//			Pen cbBorderPen = new Pen(Color.Red);
		//			Rectangle rect = new Rectangle(
		//					location.X,
		//					location.Y,
		//					size.Width - 1,
		//					size.Height - 1);

		//			e.Graphics.DrawRectangle(cbBorderPen, rect);
		//		}
		//	}
		//}

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
				base.OnRenderMenuItemBackground(e);
				e.Item.BackColor = Color.Black;
			}
			else
			{
				Rectangle rc = new Rectangle(1, 0, e.Item.Size.Width - 1, e.Item.Height);
				if (darkMode)
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), rc);
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), rc);
				}
				e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), 1, 0, rc.Width - 1, rc.Height - 1);
				if (darkMode)
				{
					e.Item.BackColor = ThemeManager.DarkPaleColor;
				}
				else
				{
					e.Item.BackColor = ThemeManager.LightPaleColor;
				}
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
			base.OnRenderDropDownButtonBackground(e);
			e.Graphics.FillRectangle(new SolidBrush(Color.Red), new RectangleF(0, 0, 4, 4));
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if ((e.Item as ToolStripButton).Checked)
			{
				if ((e.Item as ToolStripButton).Pressed)
				{
					if (darkMode)
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), new Rectangle(1, 0, e.Item.Width - 1, e.Item.Height - 3));
					}
					else
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), new Rectangle(1, 0, e.Item.Width - 1, e.Item.Height - 3));
					}

					e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), new Rectangle(1, 0, e.Item.Width - 2, e.Item.Height - 3));
				}
				else
				{
					if (darkMode)
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkPaleColor), new Rectangle(0, 0, e.Item.Width - 2, e.Item.Height - 3));
					}
					else
					{
						e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightPaleColor), new Rectangle(0, 0, e.Item.Width - 2, e.Item.Height - 3));
					}

					e.Graphics.DrawRectangle(new Pen(ThemeManager.AccentColor), new Rectangle(0, 0, e.Item.Width - 2, e.Item.Height - 3));
				}
			}
		}
	}
}
