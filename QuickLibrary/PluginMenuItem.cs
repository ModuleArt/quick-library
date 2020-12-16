using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class PluginMenuItem : ToolStripMenuItem
	{
		private string dllPath;

		public PluginMenuItem(
			object input, // bitmap
			string path,
			bool darkMode,
			PluginInfo pi,
			PluginInfo.Function func,
			string applyText,
			string configureText,
			bool alwaysOnTop,
			string langCode
		)
		{
			Text = func.title.Get(langCode);
			dllPath = Path.Combine(PluginMan.pluginsFolder, pi.name, pi.name + ".dll");

			if (func.inputRequired)
			{
				Enabled = input != null;
			}

			if (func.type == "effect")
			{
				ToolStripMenuItem apply = new ToolStripMenuItem(applyText);
				apply.Click += (s, e) =>
				{
					Object res;
					if (pi.dllType == "cpp")
					{
						IntPtr pluginPtr = NativeMan.LoadLibrary(dllPath);
						IntPtr funcPtr = NativeMan.GetProcAddressOrdinal(pluginPtr, func.name);
						var callback = Marshal.GetDelegateForFunctionPointer<PluginMan.RunFunction>(funcPtr);
						res = callback(input, path);
					}
					else if (pi.dllType == "csharp")
					{
						Assembly assembly = Assembly.LoadFrom(dllPath);
						Type type = assembly.GetType(Path.GetFileNameWithoutExtension(dllPath).Replace("-", "_") + ".Main");
						object instance = Activator.CreateInstance(type);
						res = type.GetMethod(func.name).Invoke(instance, new object[] {
						input,
						path
					}) as Object;

						OutputEventArgs oea = new OutputEventArgs
						{
							input = res
						};
						OnOutput(oea);
					}
				};
				DropDownItems.Add(apply);

				if (func.configurable)
				{
					ToolStripMenuItem conf = new ToolStripMenuItem(configureText + " ...");
					conf.Click += (s, e) =>
					{
						if (pi.dllType == "cpp")
						{
							IntPtr pluginPtr = NativeMan.LoadLibrary(dllPath);
							IntPtr funcPtr = NativeMan.GetProcAddressOrdinal(pluginPtr, func.name + "_conf");
							var callback = Marshal.GetDelegateForFunctionPointer<PluginMan.ConfFunction>(funcPtr);
							callback(input, path, darkMode, langCode, alwaysOnTop);
						}
						else if (pi.dllType == "csharp")
						{
							Assembly assembly = Assembly.LoadFrom(dllPath);
							Type type = assembly.GetType(Path.GetFileNameWithoutExtension(dllPath).Replace("-", "_") + ".Main");
							object instance = Activator.CreateInstance(type);
							type.GetMethod(func.name + "_conf").Invoke(instance, new object[] {
								input,
								path,
								darkMode,
								langCode,
								alwaysOnTop
							});
						}
					};
					if (darkMode)
					{
						conf.Image = Properties.Resources.white_options;
					}
					else
					{
						conf.Image = Properties.Resources.black_options;
					}
					DropDownItems.Add(conf);
				}

				Image = PluginMan.GetPluginIcon(pi.name, func.name, darkMode);
				if (darkMode)
				{
					DropDown.BackColor = ThemeManager.DarkSecondColor;
					apply.Image = Properties.Resources.white_check;
				}
				else
				{
					DropDown.BackColor = ThemeManager.LightSecondColor;
					apply.Image = Properties.Resources.black_check;
				}
			} 
			else if (func.type == "tool")
			{
				Text += " ...";
				Click += (s, e) =>
				{
					if (pi.dllType == "cpp")
					{
						IntPtr pluginPtr = NativeMan.LoadLibrary(dllPath);
						IntPtr funcPtr = NativeMan.GetProcAddressOrdinal(pluginPtr, func.name + "_tool");
						var callback = Marshal.GetDelegateForFunctionPointer<PluginMan.ConfFunction>(funcPtr);
						callback(input, path, darkMode, langCode, alwaysOnTop);
					}
					else if (pi.dllType == "csharp")
					{
						Assembly assembly = Assembly.LoadFrom(dllPath);
						Type type = assembly.GetType(Path.GetFileNameWithoutExtension(dllPath).Replace("-", "_") + ".Main");
						object instance = Activator.CreateInstance(type);
						type.GetMethod(func.name + "_tool").Invoke(instance, new object[] {
							input,
							path,
							darkMode,
							langCode,
							alwaysOnTop
						});
					}
				};
				Image = PluginMan.GetPluginIcon(pi.name, func.name, darkMode);
			}
		}

		protected virtual void OnOutput(OutputEventArgs e)
		{
			Output?.Invoke(this, e);
		}
		public event EventHandler<OutputEventArgs> Output;
	}

	public class OutputEventArgs : EventArgs
	{
		public Object input { get; set; }
	}
}
