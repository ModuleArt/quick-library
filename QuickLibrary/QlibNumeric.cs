using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibNumeric : Panel
	{
		// PRIVATE FIELDS

		private InternalNumericUpDown numeric;
		private Button upBtn;
		private Button downBtn;
		private bool darkMode = false;

		// HIDDEN PROPS

		[Browsable(false)]
		public new string Text => base.Text;

		[Browsable(false)]
		public new Image BackgroundImage => base.BackgroundImage;

		[Browsable(false)]
		public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

		[Browsable(false)]
		public new Color ForeColor => base.ForeColor;

		[Browsable(false)]
		public new Color BackColor => base.BackColor;

		[Browsable(false)]
		public new Cursor Cursor => base.Cursor;

		[Browsable(false)]
		public new BorderStyle BorderStyle => base.BorderStyle;

		[Browsable(false)]
		public new Font Font => base.Font;

		[Browsable(false)]
		public new bool AutoScroll => base.AutoScroll;

		[Browsable(false)]
		public new bool AutoSize => base.AutoSize;

		[Browsable(false)]
		public new AutoSizeMode AutoSizeMode => base.AutoSizeMode;

		[Browsable(false)]
		public new Padding Padding => base.Padding;

		[Browsable(false)]
		public new RightToLeft RightToLeft => base.RightToLeft;

		// PUBLIC PROPS

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

		// CONSTRUCTOR

		public QlibNumeric()
		{
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

			base.Cursor = Cursors.IBeam;

			SizeChanged += QlibNumericBox_SizeChanged;
			GotFocus += QlibNumericBox_GotFocus;
			Click += QlibNumericBox_Click;
			
			numeric.ValueChanged += Numeric_ValueChanged;
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			numeric.DownButton();
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			numeric.UpButton();
		}

		// PRIVATE BODY

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

		// PUBLIC METHODS

		private void SetDarkMode(bool dark)
		{
			darkMode = dark;

			if (dark)
			{
				base.BackColor = ThemeManager.DarkSecondColor;
				numeric.ForeColor = Color.White;
			}
			else
			{
				base.BackColor = ThemeManager.LightSecondColor;
				numeric.ForeColor = Color.Black;
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

		// EVENTS

		protected virtual void OnValueChanged(EventArgs e)
		{
			ValueChanged?.Invoke(this, e);
		}

		public event EventHandler ValueChanged;
	}
}
