using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System;

namespace QuickLibrary
{
	public class QlibMenuSeparator : ToolStripSeparator
	{
		// LOCKED VARIABLES

		[Browsable(false), Obsolete("Don't use this! (Margins = 4, 4, 4, 4)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum Margin { };

		public QlibMenuSeparator() 
		{
			base.Margin = new Padding(4, 4, 4, 4);	
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int y = e.ClipRectangle.Y + (e.ClipRectangle.Height / 2) - 1;
			e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor), e.ClipRectangle.X + 10, y, e.ClipRectangle.Width - 11, y);
		}
	}
}
