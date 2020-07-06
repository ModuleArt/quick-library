using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary 
{
	public class QlibTextBox : TextBox
	{
		public QlibTextBox()
		{
			this.AutoSize = false;
			this.Height = 25;
		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				this.BackColor = ThemeManager.DarkSecondColor;
				this.ForeColor = Color.White;
			}
		}
	}
}
