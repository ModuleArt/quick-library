using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibComboBox : ComboBox
	{
		private bool darkMode = false;
		private bool hovered = false;

		public QlibComboBox()
		{
			SetStyle(ControlStyles.UserPaint, true);
			this.DrawMode = DrawMode.OwnerDrawFixed;

			this.MouseEnter += CustomComboBox_MouseEnter;
			this.MouseLeave += CustomComboBox_MouseLeave;
		}

		private void CustomComboBox_MouseLeave(object sender, System.EventArgs e)
		{
			hovered = false;
			this.Refresh();
		}

		private void CustomComboBox_MouseEnter(object sender, System.EventArgs e)
		{
			hovered = true;
			this.Refresh();
		}

		public void SetDarkMode(bool dark)
		{
			this.darkMode = dark;

			if (dark)
			{
				this.BackColor = ThemeManager.DarkSecondColor;
				this.ForeColor = Color.White;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (darkMode)
			{
				e.Graphics.Clear(ThemeManager.DarkSecondColor);
			}
			else
			{
				e.Graphics.Clear(ThemeManager.LightSecondColor);
			}

			if (this.hovered)
			{
				if (darkMode)
				{
					e.Graphics.Clear(ThemeManager.DarkHoverColor);
				}
				else
				{
					e.Graphics.Clear(ThemeManager.LightHoverColor);
				}
			}

			e.Graphics.FillPolygon(new SolidBrush(this.ForeColor), new PointF[]
			{
				new PointF(this.Width - 19, 14),
				new PointF(this.Width - 15, 18),
				new PointF(this.Width - 11, 14)
			});

			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 12, 7);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			if (e.Index != -1)
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (!darkMode && (e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, Brushes.White, e.Bounds.X, e.Bounds.Y);
				}
				else
				{
					e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(this.ForeColor), e.Bounds.X, e.Bounds.Y);
				}
			}
		}
	}
}
