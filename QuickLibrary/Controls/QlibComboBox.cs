using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibComboBox : ComboBox
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;
		private bool hovered = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new DrawMode DrawMode { get { return base.DrawMode; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ComboBoxStyle DropDownStyle { get { return base.DropDownStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MinimumSize { get { return base.MinimumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size MaximumSize { get { return base.MaximumSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool CausesValidation { get { return base.CausesValidation; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new int ItemHeight { get { return base.ItemHeight; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool IntegralHeight { get { return base.IntegralHeight; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AllowDrop { get { return base.AllowDrop; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new FlatStyle FlatStyle { get { return base.FlatStyle; } set { } }

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

		public QlibComboBox()
		{
			SetStyle(ControlStyles.UserPaint, true);
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.BackColor = ThemeMan.LightSecondColor;
			base.ForeColor = Color.Black;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			base.Font = ThemeMan.DefaultFont;
			base.MinimumSize = Size.Empty;
			base.MaximumSize = Size.Empty;
			base.CausesValidation = false;
			base.ItemHeight = 26;
			base.IntegralHeight = true;
			base.AllowDrop = false;
			base.RightToLeft = RightToLeft.No;
			base.FlatStyle = FlatStyle.Flat;

			MouseEnter += CustomComboBox_MouseEnter;
			MouseLeave += CustomComboBox_MouseLeave;
		}

		#endregion

		#region PRIVATE BODY

		private void CustomComboBox_MouseLeave(object sender, System.EventArgs e)
		{
			hovered = false;
			Refresh();
		}

		private void CustomComboBox_MouseEnter(object sender, System.EventArgs e)
		{
			hovered = true;
			Refresh();
		}

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;
			if (dark)
			{
				base.BackColor = ThemeMan.DarkSecondColor;
				base.ForeColor = Color.White;
			}
			else
			{
				base.BackColor = ThemeMan.LightSecondColor;
				base.ForeColor = Color.Black;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(BackColor);

			if (hovered) e.Graphics.Clear(darkMode ? ThemeMan.DarkHoverColor : ThemeMan.LightHoverColor);

			e.Graphics.FillPolygon(new SolidBrush(ForeColor), new PointF[]
			{
				new PointF(Width - 19, 14),
				new PointF(Width - 15, 18),
				new PointF(Width - 11, 14)
			});

			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 12, 7);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			if (e.Index != -1)
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (!darkMode && (e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.DrawString(Items[e.Index].ToString(), Font, Brushes.White, 11, (e.Index * ItemHeight) + 4);
				}
				else
				{
					e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(ForeColor), 11, (e.Index * ItemHeight) + 4);
				}
			}
		}

		#endregion
	}
}
