using System;
using System.Runtime.InteropServices;

namespace QuickLibrary
{
	public static class NativeMan
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
		public const int SC_RESTORE = 0xF120;
		public const int EM_SETMARGINS = 0xd3;
		public const int EC_RIGHTMARGIN = 2;
		public const int EC_LEFTMARGIN = 1;
		public const int WM_NCHITTEST = 0x84;
		public const int HTCLIENT = 0x1;
		public const int HTCAPTION = 0x2;
		public const int CS_DBLCLKS = 0x8;
		public const int WM_NCPAINT = 0x0085;
		public const int WM_ACTIVATEAPP = 0x001C;
		public const int SW_SHOW = 5;
		public const int SEE_MASK_INVOKEIDLIST = 12;
		public const int WS_EX_TRANSPARENT = 0x20;

		// ENUMS

		public enum DialogBoxCommandID : int
		{
			IDOK = 0,
			IDCANCEL = 1,
			IDABORT = 2,
			IDRETRY = 3,
			IDIGNORE = 4,
			IDYES = 5,
			IDNO = 6,
			IDCLOSE = 7,
			IDHELP = 8,
			IDTRYAGAIN = 9,
			IDCONTINUE = 10
		}

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

		[StructLayout(LayoutKind.Sequential)]
		public struct SHELLEXECUTEINFO
		{
			public int cbSize;
			public uint fMask;
			public IntPtr hwnd;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpVerb;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpFile;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpParameters;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpDirectory;
			public int nShow;
			public IntPtr hInstApp;
			public IntPtr lpIDList;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpClass;
			public IntPtr hkeyClass;
			public uint dwHotKey;
			public IntPtr hIcon;
			public IntPtr hProcess;
		}

		// KERNEL32 METHODS

		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

		[DllImport("kernel32", SetLastError = true, EntryPoint = "GetProcAddress")]
		public static extern IntPtr GetProcAddressOrdinal(IntPtr hModule, string procName);

		// USER32 METHODS

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern bool SetProcessDPIAware();

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr MB_GetString(int strId);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindowEx(IntPtr hP, IntPtr hC, string sC, string sW);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpWindowClass, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public extern static int GetScrollPos(IntPtr hWnd, int nBar);

		// DWMAPI METHODS

		[DllImport("dwmapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(out bool enabled);

		// GDI32 METHODS

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// SHELL32 METHODS

		[DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

		// CUSTOM METHODS

		public static string GetMessageBoxText(DialogBoxCommandID messageId)
		{
			string str = Marshal.PtrToStringAuto(MB_GetString((int)messageId));
			if (str[0] == '&')
			{
				str = str.Substring(1, str.Length - 1);
			}
			return str;
		}

		public static void DragWindow(IntPtr handle)
		{
			ReleaseCapture();
			SendMessage(handle, 0xA1, 0x2, 0);
		}
    }
}
