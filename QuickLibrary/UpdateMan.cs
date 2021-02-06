using System;
using System.Windows.Forms;

namespace QuickLibrary
{
	public static class UpdateMan
	{
		private static string _githubOwner;
		private static string _githubRepo;
		private static string _exeName;

		private static string _title;
		private static string _message;
		private static string _dwnldBtnText;
		private static string _whatsNewBtnText;

		private static string _updating;
		private static string _downloading;
		private static string _readyToInstall;
		private static string _failed;
		private static string _install;

		private static string _isUpToDate;

		public static void Init(string githubOwner, string githubRepo, string exeName)
		{
			_githubOwner = githubOwner;
			_githubRepo = githubRepo;
			_exeName = exeName;
		}

		public static void InitLang(string title, string message, string dwnldBtnText, string whatsNewBtnText,
									string updating, string downloading, string readyToInstall, string failed, string install,
									string isUpToDate)
		{
			_title = title;
			_message = message;
			_dwnldBtnText = dwnldBtnText;
			_whatsNewBtnText = whatsNewBtnText;

			_updating = updating;
			_downloading = downloading;
			_readyToInstall = readyToInstall;
			_failed = failed;
			_install = install;

			_isUpToDate = isUpToDate;
		}

		public static async void CheckForUpdates(bool showUpToDateDialog, bool topMost, bool darkMode, IntPtr owner)
		{
			try
			{
				UpdateChecker.Init(_githubOwner, _githubRepo);
				bool update = await UpdateChecker.CheckUpdate();

				if (update == false)
				{
					if (showUpToDateDialog)
					{
						DialogMan.ShowInfo(_isUpToDate, darkMode: darkMode);
					}
				}
				else
				{
					UpdateForm updateDialog = new UpdateForm(darkMode, _title, _message, _dwnldBtnText, _whatsNewBtnText);
					updateDialog.TopMost = topMost;

					DialogResult result = updateDialog.ShowDialog(Form.FromHandle(owner));
					if (result == DialogResult.Yes)
					{
						DownloadForm downloadBox = new DownloadForm(UpdateChecker.GetAssetUrl(_exeName), darkMode, _updating, _downloading, _readyToInstall, _failed, _install);
						downloadBox.TopMost = topMost;
						downloadBox.ShowDialog(Form.FromHandle(owner));
					}
					else
					{
						updateDialog.Dispose();
					}
				}
			}
			catch
			{
				if (showUpToDateDialog)
				{
					DialogMan.ShowInfo(_failed, darkMode: darkMode);
				}
			}
		}
	}
}
