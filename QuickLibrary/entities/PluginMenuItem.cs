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
		private PluginInfo pi;
		private PluginInfo.Function func;
		private bool darkMode;
		private string langCode;

		public PluginMenuItem(
			PluginInfo pi,
			PluginInfo.Function func,
			string langCode,
			bool darkMode
		)
		{
			this.pi = pi;
			this.func = func;
			this.darkMode = darkMode;
			this.langCode = langCode;

			Text = func.title.Get(langCode);
			dllPath = Path.Combine(PluginMan.pluginsFolder, pi.name, pi.name + ".dll");

			if (func.hotkey.ctrl)
			{
				if (func.hotkey.shift)
				{
					if (func.hotkey.alt) ShortcutKeys = Keys.Control | Keys.Shift | Keys.Alt | (Keys)func.hotkey.key;
					else ShortcutKeys = Keys.Control | Keys.Shift | (Keys)func.hotkey.key;
				}
				else
				{
					if (func.hotkey.alt) ShortcutKeys = Keys.Control | Keys.Alt | (Keys)func.hotkey.key;
					else ShortcutKeys = Keys.Control | (Keys)func.hotkey.key;
				}
			}
			else if (func.hotkey.shift)
			{
				if (func.hotkey.alt) ShortcutKeys = Keys.Shift | Keys.Alt | (Keys)func.hotkey.key;
				else ShortcutKeys = Keys.Shift | (Keys)func.hotkey.key;
			}
			else if (func.hotkey.alt)
			{
				ShortcutKeys = Keys.Alt | (Keys)func.hotkey.key;
			}
			else
			{
				ShortcutKeys = (Keys)func.hotkey.key;
			}

			if (func.dialog)
			{
				Text += " ...";
			}

			Image = PluginMan.GetPluginIcon(pi.name, func.name, darkMode);
		}

		public void ProcessPlugin(
			object input,
			string path,
			bool alwaysOnTop,
			object secondaryArg,
			Form mainForm
		)
		{
			if (func.inputRequired && input == null) return;

			if (mainForm != null && func.hideMainForm) mainForm.Hide();

			object res = null;
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
				}) as object;
			}

			if (res != null)
			{
				PluginMan.OutputEventArgs oea = new PluginMan.OutputEventArgs
				{
					input = res
				};
				OnOutput(oea);
			}
		}

		protected virtual void OnOutput(PluginMan.OutputEventArgs e)
		{
			Output?.Invoke(this, e);
		}
		public event EventHandler<PluginMan.OutputEventArgs> Output;
	}
}
