﻿using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public static class DialogMan
	{
		public static DialogResult ShowConfirm(
			Form owner,
			string messageText,
			string yesBtnText = "",
			Image yesBtnImage = null,
			bool showNoBtn = false,
			string noBtnText = "",
			Image noBtnImage = null,
			string windowTitle = "",
			bool darkMode = false,
			bool topMost = false
		)
		{
			YesNoForm ynf = new YesNoForm(messageText, yesBtnText, yesBtnImage, showNoBtn, noBtnText, noBtnImage, windowTitle, darkMode);
			ynf.Owner = owner;
			ynf.TopMost = topMost;
			DialogResult dr = ynf.ShowDialog();
			ynf.Dispose();
			return dr;
		}

		public static DialogResult ShowInfo(
			Form owner,
			string messageText,
			string windowTitle = "",
			bool darkMode = false,
			bool topMost = false
		)
		{
			OkForm of = new OkForm(messageText, windowTitle, darkMode);
			of.Owner = owner;
			of.TopMost = topMost;
			DialogResult dr = of.ShowDialog();
			of.Dispose();
			return dr;
		}
	}
}
