using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibToolbarForm : Form
	{
        public void SetDraggableControls(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.MouseDown += Control_MouseDown;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GoDrag();
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    var p = MousePosition.X + (MousePosition.Y * 0x10000);
                    NativeMethodsManager.SendMessage(this.Handle, NativeMethodsManager.WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
                }
            }

        }

        private void GoDrag()
        {
            Cursor.Current = Cursors.SizeAll;
            NativeMethodsManager.ReleaseCapture();
            NativeMethodsManager.SendMessage(Handle, 0xA1, 0x2, 0);
        }

        protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
                cp.Style &= ~(0x00C00000);
				//cp.Style &= ~(0x00C00000 | 0x00040000);
				return cp;
			}
		}
        private QlibToolStrip tsNonClientToolStrip = new QlibToolStrip();

        [Category("Options"), Browsable(true), Description("Enable tab drag&drop")]
        public QlibToolStrip ToolStrip
        {
            get
            {
                return this.tsNonClientToolStrip;
            }

            set
            {
                this.tsNonClientToolStrip = value;
            }
        }

        Dwm.MARGINS dwmMargins;
        bool _marginOk;
        private bool _aeroEnabled;

        public QlibToolbarForm()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);

            //InitializeComponent();

            tsNonClientToolStrip.Renderer = new NonClientAreaRenderer();
            DoubleBuffered = true;

            CheckGlassEnabled();
        }

        /// <summary>
        /// Gets if aero is enabled
        /// </summary>
        public bool AeroEnabled
        {
            get { return _aeroEnabled; }
        }

        /// <summary>
        /// Sets the value of AeroEnabled
        /// </summary>
        private void CheckGlassEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                int response = Dwm.DwmIsCompositionEnabled(ref enabled);

                _aeroEnabled = enabled == 1;
            }
        }

        /// <summary>
        /// Equivalent to the LoWord C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        public static int LoWord(int dwValue)
        {
            return dwValue & 0xFFFF;
        }

        /// <summary>
        /// Equivalent to the HiWord C Macro
        /// </summary>
        /// <param name="dwValue"></param>
        /// <returns></returns>
        public static int HiWord(int dwValue)
        {
            return (dwValue >> 16) & 0xFFFF;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            tsNonClientToolStrip.MaximumSize = new Size(Width - 100 - tsNonClientToolStrip.Left, 0);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (dwmMargins.cyTopHeight < tsNonClientToolStrip.Bottom)
            {
                dwmMargins.cyTopHeight = tsNonClientToolStrip.Bottom;
            }

            Dwm.DwmExtendFrameIntoClientArea(this.Handle, ref dwmMargins);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_aeroEnabled)
            {
                e.Graphics.Clear(Color.Transparent);
            }
            else
            {
                e.Graphics.Clear(Color.FromArgb(0xC2, 0xD9, 0xF7));
            }

            e.Graphics.FillRectangle(SystemBrushes.ButtonFace,
                    Rectangle.FromLTRB(
                        dwmMargins.cxLeftWidth - 0,
                        dwmMargins.cyTopHeight - 0,
                        Width - dwmMargins.cxRightWidth - 0,
                        Height - dwmMargins.cyBottomHeight - 0));
        }

        protected override void WndProc(ref Message m)
        {
            int WM_NCCALCSIZE = 0x83;
            int WM_NCHITTEST = 0x84;
            IntPtr result;

            int dwmHandled = Dwm.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out result);

            if (dwmHandled == 1)
            {
                m.Result = result;
                return;
            }

            if (m.Msg == WM_NCCALCSIZE && (int)m.WParam == 1)
            {
                NCCALCSIZE_PARAMS nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

                // Adjust (shrink) the client rectangle to accommodate the border:
                nccsp.rect0.Top += 0;
                nccsp.rect0.Bottom += 0;
                nccsp.rect0.Left += 0;
                nccsp.rect0.Right += 0;

                if (!_marginOk)
                {
                    //Set what client area would be for passing to DwmExtendIntoClientArea
                    dwmMargins.cyTopHeight = nccsp.rect2.Top - nccsp.rect1.Top;
                    dwmMargins.cxLeftWidth = nccsp.rect2.Left - nccsp.rect1.Left;
                    dwmMargins.cyBottomHeight = nccsp.rect1.Bottom - nccsp.rect2.Bottom;
                    dwmMargins.cxRightWidth = nccsp.rect1.Right - nccsp.rect2.Right;
                    _marginOk = true;
                }

                Marshal.StructureToPtr(nccsp, m.LParam, false);

                m.Result = IntPtr.Zero;
            }
            else if (m.Msg == WM_NCHITTEST && (int)m.Result == 0)
            {
                m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private IntPtr HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
        {
            int HTNOWHERE = 0;
            int HTCLIENT = 1;
            int HTCAPTION = 2;
            int HTGROWBOX = 4;
            int HTSIZE = HTGROWBOX;
            int HTMINBUTTON = 8;
            int HTMAXBUTTON = 9;
            int HTLEFT = 10;
            int HTRIGHT = 11;
            int HTTOP = 12;
            int HTTOPLEFT = 13;
            int HTTOPRIGHT = 14;
            int HTBOTTOM = 15;
            int HTBOTTOMLEFT = 16;
            int HTBOTTOMRIGHT = 17;
            int HTREDUCE = HTMINBUTTON;
            int HTZOOM = HTMAXBUTTON;
            int HTSIZEFIRST = HTLEFT;
            int HTSIZELAST = HTBOTTOMRIGHT;

            Point p = new Point(LoWord((int)lparam), HiWord((int)lparam));

            Rectangle topleft = RectangleToScreen(new Rectangle(0, 0, dwmMargins.cxLeftWidth, dwmMargins.cxLeftWidth));

            if (topleft.Contains(p))
                return new IntPtr(HTTOPLEFT);

            Rectangle topright = RectangleToScreen(new Rectangle(Width - dwmMargins.cxRightWidth, 0, dwmMargins.cxRightWidth, dwmMargins.cxRightWidth));

            if (topright.Contains(p))
                return new IntPtr(HTTOPRIGHT);

            Rectangle botleft = RectangleToScreen(new Rectangle(0, Height - dwmMargins.cyBottomHeight, dwmMargins.cxLeftWidth, dwmMargins.cyBottomHeight));

            if (botleft.Contains(p))
                return new IntPtr(HTBOTTOMLEFT);

            Rectangle botright = RectangleToScreen(new Rectangle(Width - dwmMargins.cxRightWidth, Height - dwmMargins.cyBottomHeight, dwmMargins.cxRightWidth, dwmMargins.cyBottomHeight));

            if (botright.Contains(p))
                return new IntPtr(HTBOTTOMRIGHT);

            Rectangle top = RectangleToScreen(new Rectangle(0, 0, Width, dwmMargins.cxLeftWidth));

            if (top.Contains(p))
                return new IntPtr(HTTOP);

            Rectangle cap = RectangleToScreen(new Rectangle(0, dwmMargins.cxLeftWidth, Width, dwmMargins.cyTopHeight - dwmMargins.cxLeftWidth));

            if (cap.Contains(p))
                return new IntPtr(HTCAPTION);

            Rectangle left = RectangleToScreen(new Rectangle(0, 0, dwmMargins.cxLeftWidth, Height));

            if (left.Contains(p))
                return new IntPtr(HTLEFT);

            Rectangle right = RectangleToScreen(new Rectangle(Width - dwmMargins.cxRightWidth, 0, dwmMargins.cxRightWidth, Height));

            if (right.Contains(p))
                return new IntPtr(HTRIGHT);

            Rectangle bottom = RectangleToScreen(new Rectangle(0, Height - dwmMargins.cyBottomHeight, Width, dwmMargins.cyBottomHeight));

            if (bottom.Contains(p))
                return new IntPtr(HTBOTTOM);

            return new IntPtr(HTCLIENT);
        }
    }
}
