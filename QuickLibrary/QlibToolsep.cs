using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolsep : ToolStripSeparator
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;
		private bool insideMenu = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Margin { get { return base.Margin; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		[Category("Qlib props"), Browsable(true), Description("Inside menu")]
		public bool InsideMenu
		{
			get { return insideMenu; }
			set 
			{
				insideMenu = value;
				if (value)
				{
					base.Margin = new Padding(4);
				}
				else
				{
					base.Margin = new Padding(5, 0, 5, 0);
				}
			}
		}

		#endregion

		#region CONSTRUCTOR

		public QlibToolsep()
		{
			base.Margin = new Padding(5, 0, 5, 0);
		}

		#endregion

		#region PRIVATE BODY

		private void SetDarkMode(bool dark)
		{
			if (dark)
			{
				BackColor = ThemeManager.DarkSecondColor;
			}
			else
			{
				BackColor = ThemeManager.LightSecondColor;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (insideMenu)
			{
				int y = e.ClipRectangle.Y + (e.ClipRectangle.Height / 2) - 1;
				e.Graphics.DrawLine(new Pen(ThemeManager.BorderColor), e.ClipRectangle.X + 10, y, e.ClipRectangle.Width - 11, y);
			}
			else
			{
				e.Graphics.Clear(BackColor);
			}
		}

		#endregion
	}
}
