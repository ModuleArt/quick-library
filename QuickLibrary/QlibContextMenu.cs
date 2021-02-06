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
				BackColor = ThemeMan.DarkSecondColor;
			}
			else
			{
				BackColor = ThemeMan.LightSecondColor;
			}

			this.Renderer = new CustomToolStripSystemRenderer(dark);
		}
	}
}
