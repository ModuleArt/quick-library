using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibGroupBox : GroupBox
	{
		private bool darkMode = false;

		public QlibGroupBox()
		{
			this.Paint += PaintDarkGroupBox;
		}

		public void SetDarkMode(bool dark)
		{
			this.darkMode = dark;
		}

		public void PaintDarkGroupBox(object sender, PaintEventArgs p)
		{
			if (darkMode)
			{
				GroupBox box = (GroupBox)sender;

				SolidBrush brush = new SolidBrush(ThemeManager.DarkSecondColor);
				Pen pen = new Pen(brush, 1);

				p.Graphics.Clear(ThemeManager.DarkBackColor);

				p.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				p.Graphics.DrawString(box.Text, box.Font, Brushes.White, -2, -3);

				p.Graphics.DrawLine(pen, 0, 20, 0, box.Height - 2); //left border
				p.Graphics.DrawLine(pen, p.Graphics.MeasureString(box.Text, box.Font).Width + 6, 8, box.Width - 1, 8); //top border
				p.Graphics.DrawLine(pen, box.Width - 1, 8, box.Width - 1, box.Height - 2); //right border
				p.Graphics.DrawLine(pen, 0, box.Height - 2, box.Width - 1, box.Height - 2);
			}
		}
	}
}
