using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibTitlebarButton : Button
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ContentAlignment TextAlign { get { return base.TextAlign; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text { get { return base.Text; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool UseWaitCursor { get { return base.UseWaitCursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new FlatStyle FlatStyle { get { return base.FlatStyle; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Light image")]
		public Image LightImage { get; set; }

		[Category("Qlib props"), Browsable(true), Description("Dark image")]
		public Image DarkImage { get; set; }

		[Category("Qlib props"), Browsable(true), Description("Red button")]
		public bool IsRed { get; set; }

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		#endregion

		#region CONSTRUCTOR

		public QlibTitlebarButton()
		{
			base.FlatStyle = FlatStyle.Flat;
			base.TextAlign = ContentAlignment.MiddleCenter;
			base.Text = "";
			base.ForeColor = Color.Black;
			base.UseWaitCursor = false;

			MouseEnter += QlibCloseButton_MouseEnter;
			MouseLeave += QlibCloseButton_MouseLeave;
		}

		#endregion

		#region PRIVATE BODY

		private void SetDarkMode(bool darkMode)
		{
			this.darkMode = darkMode;

			if (IsRed)
			{
				FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);

				if (darkMode)
				{
					FlatAppearance.MouseDownBackColor = Color.FromArgb(139, 10, 20);
				}
				else
				{
					FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 112, 122);
				}
			}
			else
			{
				FlatAppearance.MouseDownBackColor = ThemeMan.PressedColor;

				if (darkMode)
				{
					FlatAppearance.MouseOverBackColor = ThemeMan.DarkHoverColor;
				}
				else
				{
					FlatAppearance.MouseOverBackColor = ThemeMan.LightHoverColor;
				}
			}

			QlibCloseButton_MouseLeave(this, EventArgs.Empty);
		}

		private void QlibCloseButton_MouseLeave(object sender, EventArgs e)
		{
			if (darkMode)
			{
				Image = LightImage;
			}
			else
			{
				Image = DarkImage;
			}
		}

		private void QlibCloseButton_MouseEnter(object sender, EventArgs e)
		{
			if (IsRed && !darkMode)
			{
				Image = LightImage;
			}
		}

		#endregion
	}
}
