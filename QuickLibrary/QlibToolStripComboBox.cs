using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolStripComboBox : ToolStripComboBox
	{
		private bool darkMode = false;
		//private bool hovered = false;

		public QlibToolStripComboBox()
		{
			//this.ComboBox.SetStyle(ControlStyles.UserPaint, true);
			//this
			this.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.ComboBox.DrawItem += ComboBox_DrawItem;

			this.MouseEnter += CustomComboBox_MouseEnter;
			this.MouseLeave += CustomComboBox_MouseLeave;
		}

		private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

		private void CustomComboBox_MouseLeave(object sender, System.EventArgs e)
		{
			//hovered = false;
			//this.ComboBox.Refresh();
		}

		private void CustomComboBox_MouseEnter(object sender, System.EventArgs e)
		{
			//hovered = true;
			//this.ComboBox.Refresh();
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

		//protected override void OnPaint(PaintEventArgs e)
		//{
		//	Console.WriteLine(1);

		//	if (darkMode)
		//	{
		//		e.Graphics.Clear(ThemeManager.DarkBackColor);
		//	}
		//	else
		//	{
		//		e.Graphics.Clear(ThemeManager.LightBackColor);
		//	}

		//	if (this.hovered)
		//	{
		//		if (darkMode)
		//		{
		//			e.Graphics.FillRectangle(new SolidBrush(ThemeManager.DarkHoverColor), 0, 0, this.Width, this.Height - 2);
		//		}
		//		else
		//		{
		//			e.Graphics.FillRectangle(new SolidBrush(ThemeManager.LightHoverColor), 0, 0, this.Width, this.Height - 2);
		//		}
		//	}
		//	else
		//	{
		//		e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height - 2);
		//	}

		//	Rectangle newBounds = new Rectangle(this.ComboBox.ClientRectangle.X, this.ComboBox.ClientRectangle.Y, this.ComboBox.ClientRectangle.Width, this.ComboBox.ClientRectangle.Height - 1);
		//	ControlPaint.DrawBorder(e.Graphics, newBounds, ThemeManager.BorderColor, ButtonBorderStyle.Solid);

		//	e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor), this.Width - 18, 0, this.Width - 18, this.Height - 2);
		//	e.Graphics.FillPolygon(new SolidBrush(this.ForeColor), new PointF[]
		//	{
		//		new PointF(this.Width - 13, 10),
		//		new PointF(this.Width - 9, 14),
		//		new PointF(this.Width - 5, 10)
		//	});

		//	e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		//	e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 3, 3);
		//}
	}
}
