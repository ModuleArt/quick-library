using System.Reflection;
using System.Resources;

namespace QuickLibrary
{
	public static class LangMan
	{
		private static ResourceManager resMan;

		public static string defaultLang = "en";

		public static void InitResMan(string nameSpace, string baseName = null)
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

		public static string GetString(string str)
		{
			return resMan.GetString(str);
		}
	}
}
