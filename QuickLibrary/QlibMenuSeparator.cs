﻿using System.Windows.Forms;
using System.Drawing;

namespace QuickLibrary
{
	public class QlibMenuSeparator : ToolStripSeparator
	{
		public QlibMenuSeparator() { }

		protected override void OnPaint(PaintEventArgs e)
		{
			int y = e.ClipRectangle.Y + (e.ClipRectangle.Height / 2) - 1;
			e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor), e.ClipRectangle.X + 4, y, e.ClipRectangle.Width - 5, y);
		}
	}
}
