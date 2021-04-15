using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
    public class QlibTabs : TabControl
    {
        #region PRIVATE FIELDS

        private readonly StringFormat CenterSringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        #endregion

        #region HIDDEN PROPS

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AllowDrop { get { return base.AllowDrop; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size ItemSize { get { return base.ItemSize; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new TabAppearance Appearance { get { return base.Appearance; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new TabAlignment Alignment { get { return base.Alignment; } set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool HotTrack { get { return base.HotTrack; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode { get { return base.ImeMode; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Multiline { get { return base.Multiline; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool ShowToolTips { get { return base.ShowToolTips; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new TabSizeMode SizeMode { get { return base.SizeMode; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size MinimumSize { get { return base.MinimumSize; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size MaximumSize { get { return base.MaximumSize; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font { get { return base.Font; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool RightToLeftLayout { get { return base.RightToLeftLayout; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseWaitCursor { get { return base.UseWaitCursor; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new TabDrawMode DrawMode { get { return base.DrawMode; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation { get { return base.CausesValidation; } set { } }

        #endregion

        #region PUBLIC PROPS

        [Category("Qlib props"), Browsable(true), Description("Dark mode")]
        public bool DarkMode { get; set; } = false;

        #endregion

        #region CONSTRUCTOR

        public QlibTabs()
        {
            base.AllowDrop = false;
            base.ItemSize = new Size(28, 28);
            base.Appearance = TabAppearance.Normal;
            base.Alignment = TabAlignment.Top;
            base.HotTrack = false;
            base.ImeMode = ImeMode.NoControl;
            base.Multiline = true;
            base.ShowToolTips = false;
            base.SizeMode = TabSizeMode.Normal;
            base.MinimumSize = Size.Empty;
            base.MaximumSize = Size.Empty;
            base.Font = ThemeMan.DefaultFont;
            base.RightToLeft = RightToLeft.No;
            base.RightToLeftLayout = false;
            base.UseWaitCursor = false;
            base.DrawMode = TabDrawMode.Normal;
            base.CausesValidation = false;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.OptimizedDoubleBuffer,
                true
            );
            DoubleBuffered = true;
        }

        #endregion

        #region PRIVATE BODY

        protected override void OnPaint(PaintEventArgs e)
        {
            Color headerColor = ThemeMan.LightSecondColor;
            if (DarkMode)
            {
                headerColor = ThemeMan.DarkSecondColor;
            }
            Color backTabColor = ThemeMan.LightBackColor;
            if (DarkMode)
            {
                backTabColor = ThemeMan.DarkBackColor;
            }
            Color textColor = Color.Black;
            if (DarkMode)
            {
                textColor = Color.White;
            }

            Graphics g = e.Graphics;
  
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            g.Clear(headerColor);

            if (SelectedTab != null)
            {
                SelectedTab.BackColor = backTabColor;
                SelectedTab.BorderStyle = BorderStyle.None;
            }

            g.FillRectangle(new SolidBrush(backTabColor), new Rectangle(1, Height - TabPages[0].Height - 4, Width - 2, TabPages[0].Height + 3));

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle Header = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 1, GetTabRect(i).Location.Y + 4),
                    new Size(GetTabRect(i).Width, GetTabRect(i).Height - 4)
                );
                Rectangle HeaderSize = new Rectangle(new Point(Header.Location.X + 2, Header.Location.Y), new Size(Header.Width, Header.Height));

                if (i == SelectedIndex)
                {
                    g.FillRectangle(new SolidBrush(headerColor), HeaderSize);
                    g.FillRectangle(new SolidBrush(backTabColor),  new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, Header.Height + 5));
                    g.FillRectangle(new SolidBrush(ThemeMan.AccentColor), new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, 1));
                    g.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y + 2, HeaderSize.Width, HeaderSize.Height),
                        CenterSringFormat
                    );
                }
                else
                {
                    g.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y, HeaderSize.Width, HeaderSize.Height),
                        CenterSringFormat
                    );
                }
            }
        }

		#endregion
	}
}