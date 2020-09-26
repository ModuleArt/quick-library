using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibTestForm : Form
	{
		[Browsable(false), Obsolete("Don't use this! (AutoScaleMode = Dpi)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScaleMode { };

		[Browsable(false), Obsolete("Don't use this! (HelpButton = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum HelpButton { };
		[Browsable(false), Obsolete("Don't use this! (AutoScroll = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScroll { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMargin = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMargin { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMinSize = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMinSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSize = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSizeMode = GrowAndShrink)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSizeMode { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImage = None)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImage { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImageLayout = Tile)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImageLayout { };

		[Browsable(false), Obsolete("Don't use this! (Font = ThemeManager.DefaultFont)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum Font { };

		public bool draggable = false;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= NativeMethodsManager.WS_SYSMENU | NativeMethodsManager.WS_MINIMIZEBOX | NativeMethodsManager.WS_MAXIMIZEBOX;
				//cp.Style &= ~(0x00C00000 | 0x00040000);
				return cp;

				// 0x00040000 | 
			}
		}

		//protected override void WndProc(ref Message m)
		//{
		//	if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
		//	{

		//	}
		//}

		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			public int Left;
			public int Right;
			public int Top;
			public int Bottom;
		}

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

		protected override void WndProc(ref Message m)
		{
			const UInt32 WM_NCHITTEST = 0x0084;
			const UInt32 WM_MOUSEMOVE = 0x0200;
			const UInt32 WM_ACTIVATE = 0x0006;

			const UInt32 HTLEFT = 10;
			const UInt32 HTRIGHT = 11;
			const UInt32 HTBOTTOMRIGHT = 17;
			const UInt32 HTBOTTOM = 15;
			const UInt32 HTBOTTOMLEFT = 16;
			const UInt32 HTTOP = 12;
			const UInt32 HTTOPLEFT = 13;
			const UInt32 HTTOPRIGHT = 14;

			const int RESIZE_HANDLE_SIZE = 20;
			bool handled = false;
			if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
			{
				Size formSize = this.Size;
				Point screenPoint = new Point(m.LParam.ToInt32());
				Point clientPoint = this.PointToClient(screenPoint);

				Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
					{HTBOTTOMLEFT,
						new Rectangle(-RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE)},
					{HTBOTTOM,
						new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE)},
					{HTBOTTOMRIGHT,
						new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE)},
					{HTRIGHT,
						new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE)},
					{HTTOPRIGHT,
						new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, -RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE) },
					{HTTOP,
						new Rectangle(RESIZE_HANDLE_SIZE, -RESIZE_HANDLE_SIZE, formSize.Width - 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE) },
					{HTTOPLEFT,
						new Rectangle(-RESIZE_HANDLE_SIZE, -RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE) },
					{HTLEFT,
						new Rectangle(-RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, 2 * RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE) }
				};

				foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
				{
					if (hitBox.Value.Contains(clientPoint))
					{
						m.Result = (IntPtr)hitBox.Key;
						handled = true;
						break;
					}
				}
			}
			else if (m.Msg == WM_ACTIVATE)
			{
				// Extend the frame into the client area.
				MARGINS margins = new MARGINS();

				margins.Left = 0;   
				margins.Right = 0;   
				margins.Top = -6; 
				margins.Bottom = 0;

				DwmExtendFrameIntoClientArea(this.Handle, ref margins);
			}

			if (!handled)
				base.WndProc(ref m);
		}

		//protected override void WndProc(ref Message m)
		//{
		//	const int RESIZE_HANDLE_SIZE = 10;

		//	switch (m.Msg)
		//	{
		//		case 0x0084/*NCHITTEST*/ :
		//			base.WndProc(ref m);

		//			if ((int)m.Result == 0x01/*HTCLIENT*/)
		//			{
		//				Point screenPoint = new Point(m.LParam.ToInt32());
		//				Point clientPoint = this.PointToClient(screenPoint);
		//				if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
		//				{
		//					if (clientPoint.X <= RESIZE_HANDLE_SIZE)
		//						m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
		//					else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
		//						m.Result = (IntPtr)12/*HTTOP*/ ;
		//					else
		//						m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
		//				}
		//				else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
		//				{
		//					if (clientPoint.X <= RESIZE_HANDLE_SIZE)
		//						m.Result = (IntPtr)10/*HTLEFT*/ ;
		//					else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
		//						m.Result = (IntPtr)2/*HTCAPTION*/ ;
		//					else
		//						m.Result = (IntPtr)11/*HTRIGHT*/ ;
		//				}
		//				else
		//				{
		//					if (clientPoint.X <= RESIZE_HANDLE_SIZE)
		//						m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
		//					else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
		//						m.Result = (IntPtr)15/*HTBOTTOM*/ ;
		//					else
		//						m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
		//				}
		//			}
		//			return;
		//	}
		//	base.WndProc(ref m);
		//}

		public QlibTestForm() 
		{
			base.FormBorderStyle = FormBorderStyle.Sizable;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.HelpButton = false;
			base.AutoScroll = false;
			base.AutoScrollMargin = new Size(0, 0);
			base.AutoScrollMinSize = new Size(0, 0);
			base.AutoSize = false;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.Font = ThemeManager.DefaultFont;
		}

		//protected override void OnLoad(EventArgs e)
		//{
		//	base.OnLoad(e);
		//	this.FormBorderStyle = FormBorderStyle.None;
		//}

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

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button == MouseButtons.Left && draggable)
			{
				GoDrag();
			}
		}

		private void GoDrag()
		{
			Cursor.Current = Cursors.SizeAll;
			NativeMethodsManager.ReleaseCapture();
			NativeMethodsManager.SendMessage(Handle, 0xA1, 0x2, 0);
		}
	}
}
