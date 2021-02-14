using System.Reflection;
using System.Resources;

namespace QuickLibrary
{
	public static class LangMan
	{
		private static ResourceManager resMan;

		public static string defaultLang = "en";

		public static void Init(string nameSpace, string baseName = null)
		{
			if (baseName == null)
			{
				resMan = new ResourceManager(nameSpace + ".languages.lang_" + defaultLang, Assembly.GetEntryAssembly());
			}
			else
			{
				resMan = new ResourceManager(baseName, Assembly.GetEntryAssembly());
			}
		}

		public static string Get(string str)
		{
			try
			{
				return resMan.GetString(str);
			}
			catch
			{
				return str;
			}
		}
	}
}
