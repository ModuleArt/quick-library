using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibContextMenuStrip : ContextMenuStrip
	{
		public QlibContextMenuStrip(System.ComponentModel.IContainer components) : base(components)
		{

		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				BackColor = ThemeManager.DarkSecondColor;
			}
			else
			{
				BackColor = ThemeManager.LightSecondColor;
			}

			this.Renderer = new CustomToolStripSystemRenderer(dark);
		}
	}
}
