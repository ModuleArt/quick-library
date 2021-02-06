using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibProgressBar : ProgressBar
	{
		#region PRIVATE FIELDS

		private SolidBrush barBrush = new SolidBrush(ThemeMan.AccentColor);
		private Pen borderPen = new Pen(ThemeMan.AccentColor, 1);

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode { get; set; }

		#endregion

		#region CONSTRUCTOR

		public QlibProgressBar()
		{
			SetStyle(ControlStyles.UserPaint, true);
		}

		#endregion

		#region PRIVATE BODY

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rec = e.ClipRectangle;

			rec.Width = (int)(rec.Width * ((double)Value / Maximum));
			if (ProgressBarRenderer.IsSupported)
			{
				ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
			}
				
			rec.Height = rec.Height;

			if (DarkMode)
			{
				e.Graphics.Clear(ThemeMan.DarkPaleColor);
			}
			else
			{
				e.Graphics.Clear(ThemeMan.LightPaleColor);
			}

			e.Graphics.DrawRectangle(borderPen, 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
			e.Graphics.FillRectangle(barBrush, rec);
		}

		#endregion
	}
}
