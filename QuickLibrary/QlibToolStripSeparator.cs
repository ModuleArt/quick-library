using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolStripSeparator : ToolStripSeparator
	{
		public QlibToolStripSeparator()
		{

		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				this.BackColor = ThemeManager.DarkSecondColor;
			}
			else
			{
				this.BackColor = ThemeManager.LightSecondColor;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(this.BackColor);
		}
	}
}
