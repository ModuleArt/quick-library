using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.ComponentModel;
using System;

namespace QuickLibrary
{
	public class QlibListView : ListView
	{
		// LOCKED VARIABLES

		[Browsable(false), Obsolete("Don't use this! (OnwerDraw = True)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum OwnerDraw { };


		private Color headerColor = ThemeManager.LightSecondColor;

		public QlibListView() 
		{
			base.OwnerDraw = true;
		}

		public void SetDarkMode(bool dark)
		{
			if (dark)
			{
				this.BackColor = ThemeManager.DarkBackColor;
				this.headerColor = ThemeManager.DarkSecondColor;
				this.ForeColor = Color.White;
			}
			else
			{
				this.BackColor = ThemeManager.LightBackColor;
				this.headerColor = ThemeManager.LightSecondColor;
				this.ForeColor = Color.Black;
			}
		}

		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			base.OnDrawColumnHeader(e);

			using (SolidBrush backBrush = new SolidBrush(headerColor))
			{
				e.Graphics.FillRectangle(backBrush, e.Bounds);
			}

			if (e.Header.Index != this.Columns.Count - 1)
			{
				using (Pen borderPen = new Pen(this.BackColor))
				{
					e.Graphics.DrawLine(borderPen, e.Bounds.X + e.Bounds.Width - 1, e.Bounds.Y, e.Bounds.X + e.Bounds.Width - 1, e.Bounds.Height);
				}
			}

			using (SolidBrush foreBrush = new SolidBrush(this.ForeColor))
			{
				Rectangle newBounds = e.Bounds;
				newBounds.X += 6;
				newBounds.Y += 3;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, newBounds);
			}
		}

		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			base.OnDrawItem(e);
			e.DrawDefault = true;
		}
	}
}
