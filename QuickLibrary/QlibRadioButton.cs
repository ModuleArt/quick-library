using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibRadioButton : RadioButton
	{
		private bool darkMode = false;
		private string darkText;

		public string Text
		{
			get
			{
				if (darkMode)
				{
					return darkText;
				}
				else
				{
					return base.Text;
				}
			}

			set
			{
				if (darkMode)
				{
					darkText = value;
				}
				else
				{
					base.Text = value;
				}
			}
		}

		public QlibRadioButton()
		{
			if (darkMode)
			{
				SetStyle(ControlStyles.UserPaint, true);
				this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			}
		}

		public void SetDarkMode(bool dark)
		{
			this.darkMode = dark;

			if (dark)
			{
				darkText = this.Text;
				this.Text = " ";
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (darkMode)
			{
				int top = (this.Height / 2) - 8;

				e.Graphics.Clear(ThemeManager.DarkBackColor);

				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.FillEllipse(new SolidBrush(ThemeManager.DarkSecondColor), new Rectangle(0, top + 2, 13, 13));
				
				if (this.Focused)
				{
					e.Graphics.DrawEllipse(new Pen(ThemeManager.BorderColor, 2), new Rectangle(1, top + 3, 11, 11));
				}

				if (this.Checked)
				{
					if (this.Enabled)
					{
						e.Graphics.FillEllipse(new SolidBrush(this.ForeColor), new Rectangle(3, top + 5, 7, 7));
					}
					else
					{
						e.Graphics.FillEllipse(new SolidBrush(ThemeManager.BorderColor), new Rectangle(3, top + 5, 7, 7));
					}
				}

				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (this.Enabled)
				{
					e.Graphics.DrawString(darkText, this.Font, new SolidBrush(this.ForeColor), 17, top);
				}
				else
				{
					e.Graphics.DrawString(darkText, this.Font, new SolidBrush(ThemeManager.BorderColor), 17, top);
				}
			}
			else
			{
				base.OnPaint(e);
			}
		}
	}
}
