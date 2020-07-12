using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibSizableForm : Form
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

		public const int WS_SYSMENU = 0x80000;
		public const int CS_DROPSHADOW = 0x20000;

		const int WM_NCHITTEST = 0x0084;
		const int HTCLIENT = 1;
		const int HTCAPTION = 2;

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			switch (m.Msg)
			{
				case WM_NCHITTEST:
					if (m.Result == (IntPtr)HTCLIENT)
					{
						m.Result = (IntPtr)HTCAPTION;
					}
					break;
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= 0x40000;
				return cp;
			}
		}


		//protected override CreateParams CreateParams
		//{
		//	get
		//	{
		//		CreateParams cp = base.CreateParams;
		//		cp.ClassStyle |= 0x20000;
		//		return cp;
		//	}
		//}

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

		public QlibSizableForm() 
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

			this.Load += QlibSizableForm_Load;
		}

		private void QlibSizableForm_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
		}

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
