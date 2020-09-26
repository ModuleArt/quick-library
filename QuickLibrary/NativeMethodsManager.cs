using System;
using System.Runtime.InteropServices;


namespace QuickLibrary
{
	public static class NativeMethodsManager
	{
		// CONSTANTS

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;
		public const int GWL_HWNDPARENT = -8;
		public const int WS_SYSMENU = 0x80000;
		public const int CS_DROPSHADOW = 0x20000;
		public const int WS_MINIMIZEBOX = 0x20000;
		public const int WS_MAXIMIZEBOX = 0x10000;
		public const int WM_POPUPSYSTEMMENU = 0x313;
		public const int WM_SYSCOMMAND = 0x0112;
		public const int SC_MAXIMIZE = 0xF030;
		public const int EM_SETMARGINS = 0xd3;
		public const int EC_RIGHTMARGIN = 2;
		public const int EC_LEFTMARGIN = 1;

		// ENUMS

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

		// STRUCTURES

		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			public int Left;
			public int Right;
			public int Top;
			public int Bottom;
		}

		// USER32 METHODS

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
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

		[DllImport("user32.dll")]
		public extern static int GetScrollPos(IntPtr hWnd, int nBar);

		// DWMAPI METHODS

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
	}
}
