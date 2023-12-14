using System;
using System.IO;

namespace QuickLibrary
{
	public static class FileMan
	{
		public static string GetFileSizeStr(string filePath)
		{
			return GetFileSizeStr(new FileInfo(filePath).Length);
		}

		public static string GetFileSizeStr(double fileLength)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (fileLength >= 1024 && order < sizes.Length - 1)
			{
				order++;
				fileLength = fileLength / 1024;
			}
			return String.Format("{0:0.##} {1}", fileLength, sizes[order]);
		}

		public static void MoveFileOrFolderToRecycleBin(string path)
		{
			NativeMan.SHFILEOPSTRUCT fileop = new NativeMan.SHFILEOPSTRUCT();
			fileop.wFunc = NativeMan.FO_DELETE;
			fileop.pFrom = path + '\0' + '\0';
			fileop.fFlags = NativeMan.FOF_ALLOWUNDO | NativeMan.FOF_NOCONFIRMATION;
			NativeMan.SHFileOperation(ref fileop);
		}
	}
}
