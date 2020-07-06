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
