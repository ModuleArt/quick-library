using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace QuickLibrary
{
	public class PluginMan
	{
		public static string pluginsFolder = null;
		public static int apiVer = 4;
		public static string inputType = null;

		public delegate string[] RunFunction(
			object input = null,
			string path = null,
			bool darkMode = false,
			string language = "en",
			bool alwaysOnTop = false,
			object secondaryArg = null
		);

		public delegate void PluginOutput(object sender, OutputEventArgs oea);

		public class OutputEventArgs : EventArgs
		{
			public object input { get; set; }
		}

		public static string GenerateCacheStr()
		{
			return Convert.ToBase64String(SerializeMan.ObjectToByteArray(GetPlugins()));
		}

		public static PluginInfo[] GetPluginsCache(string cacheStr)
		{
			if (cacheStr.Length > 0) return SerializeMan.ByteArrayToObject(Convert.FromBase64String(cacheStr)) as PluginInfo[];
			else return new PluginInfo[] { };
		}

		private static PluginInfo[] GetPlugins()
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
						if (pi.apiVer == apiVer && pi.inputType == inputType) plugins.Add(pi);
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
				if (File.Exists(path)) return Bitmap.FromFile(path);

				path = Path.Combine(pluginsFolder, pluginName, funcName + ".png");
				if (File.Exists(path)) return Bitmap.FromFile(path);

				return null;
			}
			else
			{
				string path = Path.Combine(pluginsFolder, pluginName, funcName + ".light.png");
				if (File.Exists(path)) return Bitmap.FromFile(path);

				path = Path.Combine(pluginsFolder, pluginName, funcName + ".png");
				if (File.Exists(path)) return Bitmap.FromFile(path);

				return null;
			}
		}
	}
}
