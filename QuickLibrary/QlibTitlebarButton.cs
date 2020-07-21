using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibTitlebarButton : Button
	{
		[Description("Light icon"), Category("Options")]
		public Image LightImage { get; set; }

		[Description("Dark icon"), Category("Options")]
		public Image DarkImage { get; set; }

		[Description("Red button"), Category("Options")]
		public bool IsRed { get; set; }

		private bool darkMode = false;

		public QlibTitlebarButton()
		{
			this.FlatStyle = FlatStyle.Flat;

			this.MouseEnter += QlibCloseButton_MouseEnter;
			this.MouseLeave += QlibCloseButton_MouseLeave;
		}

		public void SetDarkMode(bool darkMode)
		{
			this.darkMode = darkMode;

			if (IsRed)
			{
				this.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);

				if (darkMode)
				{
					this.FlatAppearance.MouseDownBackColor = Color.FromArgb(139, 10, 20);
				}
				else
				{
					this.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 112, 122);
				}
			}
			else
			{
				this.FlatAppearance.MouseDownBackColor = ThemeManager.PressedColor;

				if (darkMode)
				{
					this.FlatAppearance.MouseOverBackColor = ThemeManager.DarkHoverColor;
				}
				else
				{
					this.FlatAppearance.MouseOverBackColor = ThemeManager.LightHoverColor;
				}
			}

			QlibCloseButton_MouseLeave(this, EventArgs.Empty);
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
			if (IsRed && !darkMode)
			{
				this.Image = LightImage;
			}
		}
	}
}
