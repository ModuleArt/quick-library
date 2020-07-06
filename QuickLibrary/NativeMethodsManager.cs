using System;
using System.Runtime.InteropServices;


namespace QuickLibrary
{
	public static class NativeMethodsManager
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;
		public const int GWL_HWNDPARENT = -8;

		public enum ScrollBarType : uint
		{
			SbHorz = 0,
			SbVert = 1,
			SbCtl = 2,
			SbBoth = 3
		}

		public enum Message : uint
		{
			WM_VSCROLL = 0x0115
		}

		public enum ScrollBarCommands : uint
		{
			SB_LINEDOWN = 1,
			SB_THUMBPOSITION = 4
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("User32.dll")]
		public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr hP, IntPtr hC, string sC, string sW);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpWindowClass, string lpWindowName);

		[DllImport("User32.dll")]
		public extern static int GetScrollPos(IntPtr hWnd, int nBar);
	}
}
