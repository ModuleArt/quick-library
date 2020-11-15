using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibNumeric : Panel
	{
		#region PRIVATE FIELDS

		private InternalNumericUpDown numeric;
		private Button upBtn;
		private Button downBtn;
		private bool darkMode = false;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text { get { return base.Text; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Cursor Cursor { get { return base.Cursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoScroll { get { return base.AutoScroll; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new AutoSizeMode AutoSizeMode { get { return base.AutoSizeMode; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Value")]
		public decimal Value
		{
			get { return numeric.Value; }
			set { numeric.Value = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Maximum")]
		public decimal Maximum
		{
			get { return numeric.Maximum; }
			set { numeric.Maximum = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Minimum")]
		public decimal Minimum
		{
			get { return numeric.Minimum; }
			set { numeric.Minimum = value; }
		}

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value); }
		}

		#endregion

		#region CONSTRUCTOR

		public QlibNumeric()
		{
			base.BackgroundImageLayout = ImageLayout.None;
			base.BackgroundImage = null;
			base.Font = ThemeManager.DefaultFont;
			base.RightToLeft = RightToLeft.No;
			base.Padding = Padding.Empty;
			base.AutoScroll = false;
			base.AutoSize = false;
			base.AutoSizeMode = AutoSizeMode;
			base.BorderStyle = BorderStyle.None;
			base.BackColor = ThemeManager.LightBackColor;
			base.ForeColor = Color.Black;
			base.Cursor = Cursors.IBeam;
			base.Text = string.Empty;

			numeric = new InternalNumericUpDown();
			numeric.Location = new Point(7, 7);
			numeric.BorderStyle = BorderStyle.None;
			numeric.BackColor = BackColor;
			Controls.Add(numeric);

			upBtn = new Button();
			upBtn.Size = new Size(21, 16);
			upBtn.BackColor = BackColor;
			upBtn.FlatStyle = FlatStyle.Flat;
			upBtn.FlatAppearance.BorderSize = 0;
			upBtn.Cursor = Cursors.Default;
			upBtn.ImageAlign = ContentAlignment.MiddleCenter;
			upBtn.Padding = Padding.Empty;
			upBtn.Click += UpBtn_Click;
			Controls.Add(upBtn);

			downBtn = new Button();
			downBtn.Size = new Size(21, 16);
			downBtn.BackColor = BackColor;
			downBtn.FlatStyle = FlatStyle.Flat;
			downBtn.FlatAppearance.BorderSize = 0;
			downBtn.Cursor = Cursors.Default;
			downBtn.Click += DownBtn_Click;
			Controls.Add(downBtn);

			numeric.SendToBack();

			SizeChanged += QlibNumericBox_SizeChanged;
			GotFocus += QlibNumericBox_GotFocus;
			Click += QlibNumericBox_Click;
			
			numeric.ValueChanged += Numeric_ValueChanged;
		}

		#endregion

		#region PRIVATE BODY

		private void DownBtn_Click(object sender, EventArgs e)
		{
			numeric.DownButton();
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			numeric.UpButton();
		}

		private void Numeric_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(e);
		}

		private void QlibNumericBox_Click(object sender, EventArgs e)
		{
			numeric.Select();
		}

		private void QlibNumericBox_GotFocus(object sender, EventArgs e)
		{
			numeric.Focus();
		}

		private void QlibNumericBox_SizeChanged(object sender, EventArgs e)
		{
			numeric.Size = new Size(Size.Width - 14, numeric.Size.Height);
			upBtn.Location = new Point(Size.Width - 21, 0);
			downBtn.Location = new Point(Size.Width - 21, 16);
		}

		internal class InternalNumericUpDown : NumericUpDown
		{
			public InternalNumericUpDown()
			{
				SetStyle(ControlStyles.UserPaint, true);
				Controls[0].Visible = false;
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				e.Graphics.Clear(BackColor);
			}
		}

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;

			if (dark)
			{
				base.BackColor = ThemeManager.DarkSecondColor;
				numeric.ForeColor = Color.White;
				base.ForeColor = Color.White;
			}
			else
			{
				base.BackColor = ThemeManager.LightSecondColor;
				numeric.ForeColor = Color.Black;
				base.ForeColor = Color.Black;
			}

			Bitmap upArrowBmp = new Bitmap(8, 8);
			using (Graphics g = Graphics.FromImage(upArrowBmp))
			{
				g.FillPolygon(new SolidBrush(ForeColor), new PointF[]
				{
					new PointF(-1, 6),
					new PointF(8, 6),
					new PointF(3, 1)
				});
			}
			upBtn.Image = upArrowBmp;

			Bitmap downArrowBmp = new Bitmap(8, 8);
			using (Graphics g = Graphics.FromImage(downArrowBmp))
			{
				g.FillPolygon(new SolidBrush(ForeColor), new PointF[]
				{
					new PointF(0, 0),
					new PointF(7, 0),
					new PointF(3, 4)
				});
			}
			downBtn.Image = downArrowBmp;

			numeric.BackColor = BackColor;
			upBtn.BackColor = BackColor;
			downBtn.BackColor = BackColor;
		}

		#endregion

		#region PUBLIC EVENTS

		protected virtual void OnValueChanged(EventArgs e)
		{
			ValueChanged?.Invoke(this, e);
		}

		public event EventHandler ValueChanged;

		#endregion
	}
}
