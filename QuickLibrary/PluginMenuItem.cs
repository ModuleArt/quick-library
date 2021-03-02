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
			object input,
			string path,
			bool darkMode,
			PluginInfo pi,
			PluginInfo.Function func,
			bool alwaysOnTop,
			string langCode,
			Form mainForm,
			object secondaryArg
		)
		{
			Text = func.title.Get(langCode);
			dllPath = Path.Combine(PluginMan.pluginsFolder, pi.name, pi.name + ".dll");

			if (func.dialog)
			{
				Text += " ...";
			}

			if (func.inputRequired)
			{
				Enabled = input != null;
			}

			Click += (s, e) =>
			{
				if (mainForm != null && func.hideMainForm)
				{
					mainForm.Hide();
				}

				Object res;
				if (pi.dllType == "cpp")
				{
					IntPtr pluginPtr = NativeMan.LoadLibrary(dllPath);
					IntPtr funcPtr = NativeMan.GetProcAddressOrdinal(pluginPtr, func.name);
					var callback = Marshal.GetDelegateForFunctionPointer<PluginMan.RunFunction>(funcPtr);
					res = callback(input, path, darkMode, langCode, alwaysOnTop, secondaryArg);
				}
				else if (pi.dllType == "csharp")
				{
					Assembly assembly = Assembly.LoadFrom(dllPath);
					Type type = assembly.GetType(Path.GetFileNameWithoutExtension(dllPath).Replace("-", "_") + ".Main");
					object instance = Activator.CreateInstance(type);
					res = type.GetMethod(func.name).Invoke(instance, new object[] {
						input,
						path,
						darkMode,
						langCode,
						alwaysOnTop,
						secondaryArg
					}) as Object;

					PluginMan.OutputEventArgs oea = new PluginMan.OutputEventArgs
					{
						input = res
					};
					OnOutput(oea);
				}
			};

			Image = PluginMan.GetPluginIcon(pi.name, func.name, darkMode);
		}

		protected virtual void OnOutput(PluginMan.OutputEventArgs e)
		{
			Output?.Invoke(this, e);
		}
		public event EventHandler<PluginMan.OutputEventArgs> Output;
	}
}
