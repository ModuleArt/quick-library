using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace QuickLibrary
{
	public class PluginMan
	{
		public static string pluginsFolder = null;
		public static int apiVer = 0;
		public static string inputType = null;

		public delegate Bitmap RunFunction(
			Object input = null,
			string path = null,
			string[] args = null
		);

		public delegate string[] ConfFunction(
			Object input = null,
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

		public static PluginInfo[] GetPlugins(bool onlyAvailable)
		{
			List<PluginInfo> plugins = new List<PluginInfo>();
			DirectoryInfo di = new DirectoryInfo(pluginsFolder);
			if (di.Exists)
			{
				FileInfo[] files = di.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					if (Path.GetExtension(files[i].Name) == ".json")
					{
						PluginInfo pi = PluginInfo.FromJson(File.ReadAllText(Path.Combine(di.FullName, files[i].Name)));

						if (onlyAvailable)
						{
							if (pi.apiVer == apiVer && pi.inputType == inputType)
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
