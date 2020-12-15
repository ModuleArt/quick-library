using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace QuickLibrary
{
	public class PluginMan
	{
		public static string pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
		public static int apiVer = 2;

		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

		[DllImport("kernel32", SetLastError = true, EntryPoint = "GetProcAddress")]
		public static extern IntPtr GetProcAddressOrdinal(IntPtr hModule, string procName);

		public delegate Bitmap RunFunction(
			Bitmap bmp = null,
			string path = null,
			string[] args = null
		);

		public delegate string[] ConfFunction(
			Bitmap bmp = null,
			string path = null,
			bool darkMode = false,
			string language = "en",
			bool alwaysOnTop = false
		);

		public delegate void PluginOutput(object sender, PluginOutputEventArgs poea);

		public class PluginOutputEventArgs : EventArgs
		{
			public object subject { get; set; }
		}

		public static PluginInfo[] GetPlugins(bool onlyAvailable, string pluginType)
		{
			List<PluginInfo> plugins = new List<PluginInfo>();
			DirectoryInfo di = new DirectoryInfo(pluginsFolder);
			if (di.Exists)
			{
				List<FileInfo> files = new List<FileInfo>();
				DirectoryInfo[] dirs = di.GetDirectories();
				for (int i = 0; i < dirs.Length; i++)
				{
					files.AddRange(dirs[i].GetFiles());
					dirs[i] = null;
				}
				for (int i = 0; i < files.Count; i++)
				{
					if (Path.GetExtension(files[i].Name) == ".json")
					{
						PluginInfo pi = PluginInfo.FromJson(File.ReadAllText(Path.Combine(di.FullName, files[i].DirectoryName, files[i].Name)));

						if (onlyAvailable)
						{
							if (pi.apiVer == apiVer && pi.pluginType == pluginType)
							{
								plugins.Add(pi);
							}
						}
						else
						{
							plugins.Add(pi);
						}
					}
					files[i] = null;
				}
			}
			return plugins.ToArray();
		}

		public static Image GetPluginIcon(string pluginName, string funcName, bool darkMode)
		{
			if (darkMode)
			{
				string path = Path.Combine(pluginsFolder, pluginName, funcName + ".dark.png");
				if (File.Exists(path))
				{
					return Bitmap.FromFile(path);
				}

				path = Path.Combine(pluginsFolder, pluginName, funcName + ".png");
				if (File.Exists(path))
				{
					return Bitmap.FromFile(path);
				}

				return null;
			}
			else
			{
				string path = Path.Combine(pluginsFolder, pluginName, funcName + ".light.png");
				if (File.Exists(path))
				{
					return Bitmap.FromFile(path);
				}

				path = Path.Combine(pluginsFolder, pluginName, funcName + ".png");
				if (File.Exists(path))
				{
					return Bitmap.FromFile(path);
				}

				return null;
			}
		}
	}
}
