using System;
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

        private bool darkMode = false;
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
            if (darkMode)
            {
                headerColor = ThemeMan.DarkSecondColor;
            }
            Color backTabColor = ThemeMan.LightBackColor;
            if (darkMode)
            {
                backTabColor = ThemeMan.DarkBackColor;
            }
            Color textColor = Color.Black;
            if (darkMode)
            {
                textColor = Color.White;
            }

            var g = e.Graphics;
            var Drawer = g;

            Drawer.SmoothingMode = SmoothingMode.HighQuality;
            Drawer.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Drawer.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Drawer.Clear(headerColor);
            try
            {
                SelectedTab.BackColor = backTabColor;
            }
            catch
            {
                // ignored
            }

            try
            {
                SelectedTab.BorderStyle = BorderStyle.None;
            }
            catch
            {
                // ignored
            }

            Drawer.FillRectangle(new SolidBrush(backTabColor), new Rectangle(1, this.Height - this.TabPages[0].Height - 4, Width - 2, this.TabPages[0].Height + 3));

            Drawer.InterpolationMode = InterpolationMode.HighQualityBicubic;

            for (var i = 0; i <= TabCount - 1; i++)
            {
                var Header = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 1, GetTabRect(i).Location.Y + 4),
                    new Size(GetTabRect(i).Width, GetTabRect(i).Height - 4));
                var HeaderSize = new Rectangle(new Point(Header.Location.X + 2, Header.Location.Y), new Size(Header.Width, Header.Height));

                if (i == SelectedIndex)
                {
                    Drawer.FillRectangle(new SolidBrush(headerColor), HeaderSize);

                    Drawer.FillRectangle(
                        new SolidBrush(backTabColor),
                        new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, Header.Height + 5));
                    Drawer.FillRectangle(
                        new SolidBrush(ThemeMan.AccentColor),
                        new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, 1));

                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y + 2, HeaderSize.Width, HeaderSize.Height),
                        CenterSringFormat);
                }
                else
                {
                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y, HeaderSize.Width, HeaderSize.Height),
                        CenterSringFormat);
                }
            }
        }

        private void SetDarkMode(bool dark)
        {
            darkMode = dark;
        }

		#endregion
	}
}
