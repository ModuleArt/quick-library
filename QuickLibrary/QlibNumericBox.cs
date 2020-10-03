using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibNumericBox : Panel
	{
		// PRIVATE FIELDS

		private InternalNumericUpDown numeric;

		// HIDDEN PROPS

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

		// CONSTRUCTOR

		public QlibNumericBox()
		{
			numeric = new InternalNumericUpDown();

			numeric.Location = new Point(7, 7);
			numeric.BorderStyle = BorderStyle.None;
			numeric.BackColor = BackColor;

			Controls.Add(numeric);

			base.Cursor = Cursors.IBeam;

			SizeChanged += QlibNumericBox_SizeChanged;
			GotFocus += QlibNumericBox_GotFocus;
			Click += QlibNumericBox_Click;
			
			numeric.ValueChanged += Numeric_ValueChanged;
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

				Brush arrowsBrush = new SolidBrush(ForeColor);
				if (!Enabled)
				{
					arrowsBrush = new SolidBrush(ThemeManager.BorderColor);
				}

				e.Graphics.FillPolygon(arrowsBrush, new PointF[]
				{
					new PointF(Width - 14, 15),
					new PointF(Width - 10, 19),
					new PointF(Width - 6, 15)
				});
				e.Graphics.FillPolygon(arrowsBrush, new PointF[]
				{
					new PointF(Width - 15, 10),
					new PointF(Width - 10, 5),
					new PointF(Width - 6, 10)
				});
			}

			protected override void OnMouseClick(MouseEventArgs e)
			{
				if (e.X > Width - 18)
				{
					Focus();
					if (e.Y > Height / 2)
					{
						if (Value > Minimum)
						{
							Value--;
						}
					}
					else
					{
						if (Value < Maximum)
						{
							Value++;
						}
					}
				}
			}
		}

		// PUBLIC METHODS

		public void SetDarkMode(bool dark)
		{
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
			numeric.BackColor = ThemeManager.DarkSecondColor;
		}

		// EVENTS

		protected virtual void OnValueChanged(EventArgs e)
		{
			ValueChanged?.Invoke(this, e);
		}

		public event EventHandler ValueChanged;
	}
}
