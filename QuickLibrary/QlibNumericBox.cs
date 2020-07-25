using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibNumericBox : NumericUpDown
	{
		public QlibNumericBox()
		{
			SetStyle(ControlStyles.UserPaint, true);
			this.Controls[0].Visible = false;
		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				this.BackColor = ThemeManager.DarkSecondColor;
				this.ForeColor = Color.White;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(this.BackColor);

			Brush arrowsBrush = new SolidBrush(this.ForeColor);
			if (!this.Enabled)
			{
				arrowsBrush = new SolidBrush(ThemeManager.BorderColor);
			}

			e.Graphics.FillPolygon(arrowsBrush, new PointF[]
			{
				new PointF(this.Width - 14, 15),
				new PointF(this.Width - 10, 19),
				new PointF(this.Width - 6, 15)
			});
			e.Graphics.FillPolygon(arrowsBrush, new PointF[]
			{
				new PointF(this.Width - 15, 10),
				new PointF(this.Width - 10, 5),
				new PointF(this.Width - 6, 10)
			});
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.X > this.Width - 18)
			{
				this.Focus();
				if (e.Y > this.Height / 2)
				{
					if (this.Value > this.Minimum)
					{
						this.Value--;
					}
				}
				else
				{
					if (this.Value < this.Maximum)
					{
						this.Value++;
					}
				}
			}
		}
	}
}
