using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public static class DialogMan
	{
		public static DialogResult ShowConfirmDialog(
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
			YesNoForm cf = new YesNoForm(messageText, yesBtnText, yesBtnImage, showNoBtn, noBtnText, noBtnImage, windowTitle, darkMode);
			return cf.ShowDialog();
		}
	}
}
