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

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size Size { get { return base.Size; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

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
					base.AutoSize = true;
					base.Margin = new Padding(4);
				}
				else
				{
					base.AutoSize = false;
					base.Margin = new Padding(5, 0, 5, 0);
					base.Size = new Size(1, 24);
				}
			}
		}

		#endregion

		#region CONSTRUCTOR

		public QlibToolsep()
		{
			base.Margin = new Padding(5, 0, 5, 0);
			base.ForeColor = ThemeMan.BorderColor;
			base.BackColor = ThemeMan.LightSecondColor;
			base.AutoSize = false;
			base.Size = new Size(1, 24);
			base.RightToLeft = RightToLeft.No;
		}

		#endregion

		#region PRIVATE BODY

		private void SetDarkMode(bool dark)
		{
			base.BackColor = dark ? ThemeMan.DarkSecondColor : ThemeMan.LightSecondColor;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (insideMenu)
			{
				int y = e.ClipRectangle.Y + (e.ClipRectangle.Height / 2) - 1;
				e.Graphics.DrawLine(new Pen(ForeColor), e.ClipRectangle.X + 10, y, e.ClipRectangle.Width - 11, y);
			}
			else
			{
				e.Graphics.Clear(BackColor);
			}
		}

		#endregion
	}
}
