using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibSizableForm : QlibFixedForm
	{
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
				NativeMethodsManager.MARGINS margins = new NativeMethodsManager.MARGINS();

				margins.Left = 0;
				margins.Right = 0;
				margins.Top = -6;
				margins.Bottom = 0;

				NativeMethodsManager.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
			}

			if (!handled)
				base.WndProc(ref m);
		}
	}
}
