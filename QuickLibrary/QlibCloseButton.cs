using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibCloseButton : Button
	{
		[Description("Light icon"), Category("Custom style")]
		public Image LightImage { get; set; }

		[Description("Dark icon"), Category("Custom style")]
		public Image DarkImage { get; set; }

		private bool darkMode = false;

		public QlibCloseButton()
		{
			this.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 112, 122);
			this.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);

			this.MouseEnter += QlibCloseButton_MouseEnter;
			this.MouseLeave += QlibCloseButton_MouseLeave;
		}

		private void QlibCloseButton_MouseLeave(object sender, EventArgs e)
		{
			if (darkMode)
			{
				this.Image = LightImage;
			}
			else
			{
				this.Image = DarkImage;
			}
		}

		private void QlibCloseButton_MouseEnter(object sender, EventArgs e)
		{
			if (!darkMode)
			{
				this.Image = LightImage;
			}
		}

		public void SetDarkMode(bool darkMode)
		{
			this.darkMode = darkMode;

			QlibCloseButton_MouseLeave(this, EventArgs.Empty);
		}
	}
}
