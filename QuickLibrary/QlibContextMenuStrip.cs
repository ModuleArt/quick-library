using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibContextMenuStrip : ContextMenuStrip
	{
		#region PRIVATE PROPS

		private bool darkMode = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text { get { return base.Text; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AllowDrop { get { return base.AllowDrop; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		#endregion

		#region CONSTRUCTOR

		public QlibContextMenuStrip(IContainer components) : base(components)
		{
			base.Font = ThemeMan.DefaultFont;
			base.ForeColor = Color.Black;
			base.BackColor = ThemeMan.LightSecondColor;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.RightToLeft = RightToLeft.No;
			base.Text = null;
			base.AllowDrop = false;
			base.AutoSize = true;
			base.Padding = new Padding(32, 2, 2, 2);
		}

		#endregion

		#region PRIVATE BODY

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;

			if (dark)
			{
				base.BackColor = ThemeMan.DarkSecondColor;
			}
			else
			{
				base.BackColor = ThemeMan.LightSecondColor;
			}

			foreach (var c in Items)
			{
				if (c.GetType() == typeof(ToolStripMenuItem))
				{
					if (dark)
					{
						(c as ToolStripMenuItem).BackColor = ThemeMan.DarkSecondColor;
						(c as ToolStripMenuItem).ForeColor = Color.White;
						(c as ToolStripMenuItem).DropDown.BackColor = ThemeMan.DarkSecondColor;
						(c as ToolStripMenuItem).DropDown.ForeColor = Color.White;
					}
					else
					{
						(c as ToolStripMenuItem).BackColor = ThemeMan.LightSecondColor;
						(c as ToolStripMenuItem).ForeColor = Color.Black;
						(c as ToolStripMenuItem).DropDown.BackColor = ThemeMan.LightSecondColor;
						(c as ToolStripMenuItem).DropDown.ForeColor = Color.Black;
					}
				}
			}

			Renderer = new CustomToolStripSystemRenderer(dark);
		}

		#endregion
	}
}
