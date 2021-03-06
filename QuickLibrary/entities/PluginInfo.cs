﻿using System;
using Utf8Json;

namespace QuickLibrary
{
	[Serializable]
	public class PluginInfo
	{
		#region STRUCTS

		[Serializable]
		public struct Author
		{
			public string name;
			public string link;
		}

		[Serializable]
		public struct MultilangString
		{
			public string en;
			public string cn;
			public string fr;
			public string hu;
			public string ru;
			public string es;
			
			public string Get(string langCode)
			{
				string value;
				switch (langCode)
				{
					case "cn":
						value = cn;
						break;
					case "fr":
						value = fr;
						break;
					case "hu":
						value = hu;
						break;
					case "ru":
						value = ru;
						break;
					case "es":
						value = es;
						break;
					default:
						value = en;
						break;
				}
				return value;
			}
		}

		[Serializable]
		public struct Hotkey
		{
			public bool ctrl;
			public bool shift;
			public bool alt;
			public int key;
		}

		[Serializable]
		public struct Function
		{
			public string name;
			public MultilangString title;
			public string type; 
			public bool inputRequired;
			public bool dialog;
			public bool hideMainForm;
			public Hotkey hotkey;
		}

		#endregion

		#region VARIABLES

		public string name;
		public string version;
		public string title;
		public MultilangString description;
		public string link;
		public Author[] authors;
		public int apiVer; 
		public string inputType; 
		public string dllType; 
		public Function[] functions;

		#endregion

		#region STATIC METHODS

		public static PluginInfo FromJson(string json)
		{
			return JsonSerializer.Deserialize<PluginInfo>(json);
		}

		#endregion

		#region CONSTRUCTOR

		public PluginInfo()
		{

		}

		#endregion
	}
}
