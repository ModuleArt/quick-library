using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public static class DialogMan
	{
		public static DialogResult ShowConfirm(
			string messageText,
			string yesBtnText = "",
			Image yesBtnImage = null,
			bool showNoBtn = false,
			string noBtnText = "",
			Image noBtnImage = null,
			string windowTitle = "",
			bool darkMode = false
		)
		{
			YesNoForm ynf = new YesNoForm(messageText, yesBtnText, yesBtnImage, showNoBtn, noBtnText, noBtnImage, windowTitle, darkMode);
			return ynf.ShowDialog();
		}

		public static DialogResult ShowInfo(
			string messageText,
			string windowTitle = "",
			bool darkMode = false
		)
		{
			OkForm of = new OkForm(messageText, windowTitle, darkMode);
			return of.ShowDialog();
		}
	}
}
