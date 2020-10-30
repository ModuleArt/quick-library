using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuickLibrary
{
    public class QlibTabControl : TabControl
    {
        /// <summary>
        ///     Format of the title of the TabPage
        /// </summary>
        private readonly StringFormat CenterSringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        ///     The color of the active tab header
        /// </summary>
        private Color activeColor = Color.FromArgb(0, 122, 204);

        /// <summary>
        ///     The color of the background of the Tab
        /// </summary>
        private Color backTabColor = Color.FromArgb(28, 28, 28);

        /// <summary>
        ///     Color of the closing button
        /// </summary>
        private Color closingButtonColor = Color.WhiteSmoke;

        /// <summary>
        ///     Message for the user before losing
        /// </summary>
        private string closingMessage;

        /// <summary>
        ///     The color of the tab header
        /// </summary>
        private Color headerColor = Color.FromArgb(45, 45, 48);

        /// <summary>
        ///     The color of the horizontal line which is under the headers of the tab pages
        /// </summary>
        private Color horizLineColor = Color.FromArgb(0, 122, 204);

        /// <summary>
        ///     A random page will be used to store a tab that will be deplaced in the run-time
        /// </summary>
        private TabPage predraggedTab;

        /// <summary>
        ///     The color of the text
        /// </summary>
        private Color textColor = Color.FromArgb(255, 255, 255);

        ///<summary>
        /// Shows closing buttons
        /// </summary> 
        public bool ShowClosingButton { get; set; }

        /// <summary>
        /// Enable tab drag&drop
        /// </summary>
        public bool enableDragDrop = false;

        /// <summary>
        ///     Init
        /// </summary>
        public QlibTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer,
                true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(240, 24);
            AllowDrop = true;
        }

        [Category("Options"), Browsable(true), Description("Enable tab drag&drop")]
        public bool EnableDragDrop
        {
            get
            {
                return this.enableDragDrop;
            }

            set
            {
                this.enableDragDrop = value;
            }
        }

        [Category("Colors"), Browsable(true), Description("The color of the selected page")]
        public Color ActiveColor
        {
            get
            {
                return this.activeColor;
            }

            set
            {
                this.activeColor = value;
            }
        }

        [Category("Colors"), Browsable(true), Description("The color of the background of the tab")]
        public Color BackTabColor
        {
            get
            {
                return this.backTabColor;
            }

            set
            {
                this.backTabColor = value;
            }
        }

        /// <summary>
        ///     The color of the closing button
        /// </summary>
        [Category("Colors"), Browsable(true), Description("The color of the closing button")]
        public Color ClosingButtonColor
        {
            get
            {
                return this.closingButtonColor;
            }

            set
            {
                this.closingButtonColor = value;
            }
        }

        /// <summary>
        ///     The message that will be shown before closing.
        /// </summary>
        [Category("Options"), Browsable(true), Description("The message that will be shown before closing.")]
        public string ClosingMessage
        {
            get
            {
                return this.closingMessage;
            }

            set
            {
                this.closingMessage = value;
            }
        }

        [Category("Colors"), Browsable(true), Description("The color of the header.")]
        public Color HeaderColor
        {
            get
            {
                return this.headerColor;
            }

            set
            {
                this.headerColor = value;
            }
        }

        [Category("Colors"), Browsable(true),
         Description("The color of the horizontal line which is located under the headers of the pages.")]
        public Color HorizontalLineColor
        {
            get
            {
                return this.horizLineColor;
            }

            set
            {
                this.horizLineColor = value;
            }
        }

        /// <summary>
        ///     Show a Yes/No message before closing?
        /// </summary>
        [Category("Options"), Browsable(true), Description("Show a Yes/No message before closing?")]
        public bool ShowClosingMessage { get; set; }

        [Category("Colors"), Browsable(true), Description("The color of the title of the page")]
        public Color TextColor
        {
            get
            {
                return this.textColor;
            }

            set
            {
                this.textColor = value;
            }
        }

        /// <summary>
        ///     Sets the Tabs on the top
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        /// <summary>
        ///     Drags the selected tab
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (enableDragDrop)
            {
                var draggedTab = (TabPage)drgevent.Data.GetData(typeof(TabPage));
                var pointedTab = getPointedTab();

                if (ReferenceEquals(draggedTab, predraggedTab) && pointedTab != null)
                {
                    drgevent.Effect = DragDropEffects.Move;

                    if (!ReferenceEquals(pointedTab, draggedTab))
                    {
                        this.ReplaceTabPages(draggedTab, pointedTab);
                    }
                }
            }

            base.OnDragOver(drgevent);
        }

        /// <summary>
        ///     Handles the selected tab|closes the selected page if wanted.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (enableDragDrop)
            {
                predraggedTab = getPointedTab();
            }

            var p = e.Location;
            if (!this.ShowClosingButton)
            {
            }
            else
            {
                for (var i = 0; i < this.TabCount; i++)
                {
                    var r = this.GetTabRect(i);
                    r.Offset(r.Width - 15, 2);
                    r.Width = 10;
                    r.Height = 10;
                    if (!r.Contains(p))
                    {
                        continue;
                    }

                    if (this.ShowClosingMessage)
                    {
                        if (DialogResult.Yes == MessageBox.Show(this.ClosingMessage, "Close", MessageBoxButtons.YesNo))
                        {
                            this.TabPages.RemoveAt(i);
                        }
                    }
                    else
                    {
                        this.TabPages.RemoveAt(i);
                    }
                }
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        ///     Holds the selected page until it sets down
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && predraggedTab != null)
            {
                this.DoDragDrop(predraggedTab, DragDropEffects.Move);
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        ///     Abandons the selected tab
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            predraggedTab = null;
            base.OnMouseUp(e);
        }

        /// <summary>
        ///     Draws the control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var Drawer = g;

            Drawer.SmoothingMode = SmoothingMode.HighQuality;
            Drawer.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Drawer.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Drawer.Clear(this.headerColor);
            try
            {
                SelectedTab.BackColor = this.backTabColor;
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

            // Draws the horizontal line
            //Drawer.DrawLine(new Pen(this.horizLineColor, 5), new Point(0, 19), new Point(Width, 19));

            // Draws the background of the tab control
            Drawer.FillRectangle(new SolidBrush(this.backTabColor), new Rectangle(1, this.Height - this.TabPages[0].Height - 4, Width - 2, this.TabPages[0].Height + 3));

            // Draws the border of the TabControl
            //Drawer.DrawRectangle(new Pen(this.headerColor), new Rectangle(0, 0, Width, Height));
            Drawer.InterpolationMode = InterpolationMode.HighQualityBicubic;

            for (var i = 0; i <= TabCount - 1; i++)
            {
                var Header = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 1, GetTabRect(i).Location.Y + 4),
                    new Size(GetTabRect(i).Width, GetTabRect(i).Height - 4));
                var HeaderSize = new Rectangle(new Point(Header.Location.X + 2, Header.Location.Y), new Size(Header.Width, Header.Height));
                Brush ClosingColorBrush = new SolidBrush(this.closingButtonColor);

                if (i == SelectedIndex)
                {
                    // Draws the back of the header 
                    Drawer.FillRectangle(new SolidBrush(this.headerColor), HeaderSize);

                    // Draws the back of the color when it is selected
                    Drawer.FillRectangle(
                        new SolidBrush(this.backTabColor),
                        new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, Header.Height + 5));
                    Drawer.FillRectangle(
                        new SolidBrush(this.activeColor),
                        new Rectangle(Header.X - 2, Header.Y - 3, Header.Width - 3, 1));

                    // Draws the title of the page
                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(this.textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y + 2, HeaderSize.Width, HeaderSize.Height),
                        this.CenterSringFormat);

                    // Draws the closing button
                    if (this.ShowClosingButton)
                    {
                        e.Graphics.DrawString("X", Font, ClosingColorBrush, HeaderSize.Right - 17, 3);
                    }
                }
                else
                {
                    // Simply draws the header when it is not selected
                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(this.textColor),
                        new Rectangle(HeaderSize.X - 5, HeaderSize.Y, HeaderSize.Width, HeaderSize.Height),
                        this.CenterSringFormat);
                }
            }
        }

        /// <summary>
        ///     Gets the pointed tab
        /// </summary>
        /// <returns></returns>
        private TabPage getPointedTab()
        {
            for (var i = 0; i <= this.TabPages.Count - 1; i++)
            {
                if (this.GetTabRect(i).Contains(this.PointToClient(Cursor.Position)))
                {
                    return this.TabPages[i];
                }
            }

            return null;
        }

        /// <summary>
        ///     Swaps the two tabs
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        private void ReplaceTabPages(TabPage Source, TabPage Destination)
        {
            var SourceIndex = this.TabPages.IndexOf(Source);
            var DestinationIndex = this.TabPages.IndexOf(Destination);

            this.TabPages[DestinationIndex] = Source;
            this.TabPages[SourceIndex] = Destination;

            if (this.SelectedIndex == SourceIndex)
            {
                this.SelectedIndex = DestinationIndex;
            }
            else if (this.SelectedIndex == DestinationIndex)
            {
                this.SelectedIndex = SourceIndex;
            }

            this.Refresh();
        }


    }
}
