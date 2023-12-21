using System;
using System.Windows.Forms;

namespace QuickLibrary
{
	public static class UpdateMan
	{
		private static string _githubOwner;
		private static string _githubRepo;
		private static string _exeName;
		private static bool _darkMode;
		private static string _skippedVersion;

		private static string _title;
		private static string _message;
		private static string _dwnldBtnText;
		private static string _skipBtnText;
		private static string _whatsNewBtnText;

		private static string _updating;
		private static string _downloading;
		private static string _readyToInstall;
		private static string _failed;

		public static void Init(string githubOwner, string githubRepo, string exeName, bool darkMode, string skippedVersion)
		{
			_githubOwner = githubOwner;
			_githubRepo = githubRepo;
			_exeName = exeName;
			_darkMode = darkMode;
			_skippedVersion = skippedVersion;
		}

		public static void InitLang(string title, string message, string dwnldBtnText, string skipBtnText, string whatsNewBtnText,
									string updating, string downloading, string readyToInstall, string failed)
		{
			_title = title;
			_message = message;
			_dwnldBtnText = dwnldBtnText;
			_skipBtnText = skipBtnText;
			_whatsNewBtnText = whatsNewBtnText;

			_updating = updating;
			_downloading = downloading;
			_readyToInstall = readyToInstall;
			_failed = failed;
		}

		public static async void CheckForUpdates(bool showUpToDateDialog, bool topMost, IntPtr owner)
		{
			try
			{
				UpdateChecker.Init(_githubOwner, _githubRepo);
				string update = await UpdateChecker.CheckUpdate();

				if (update == null)
				{
					if (showUpToDateDialog)
					{
						OnIsUpToDate(EventArgs.Empty);
					}
				}
				else
				{
					if (!showUpToDateDialog && _skippedVersion == update)
					{
						return;
					}

					UpdateForm updateDialog = new UpdateForm(_darkMode, _title, _message, _dwnldBtnText, _skipBtnText, _whatsNewBtnText);
					updateDialog.TopMost = topMost;

					DialogResult result = updateDialog.ShowDialog(Form.FromHandle(owner));
					if (result == DialogResult.Yes)
					{
						DownloadForm downloadBox = new DownloadForm(UpdateChecker.GetAssetUrl(_exeName), _darkMode, _updating, _downloading, _readyToInstall, _failed, _dwnldBtnText);
						downloadBox.TopMost = topMost;
						downloadBox.ShowDialog(Form.FromHandle(owner));
					}
					if (result == DialogResult.No)
					{
						UpdateSkippedEventArgs usea = new UpdateSkippedEventArgs
						{
							SkippedVersion = update
						};
						OnUpdateSkipped(usea);
					}
					else
					{
						updateDialog.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				if (showUpToDateDialog)
				{
					UpdateFailedEventArgs ufea = new UpdateFailedEventArgs
					{
						Exception = ex
					};
					OnUpdateFailed(ufea);
				}
			}
		}

		public static void OnUpdateFailed(UpdateFailedEventArgs ufea)
		{
			UpdateFailed?.Invoke(null, ufea);
		}
		public static event EventHandler<UpdateFailedEventArgs> UpdateFailed;

		public static void OnIsUpToDate(EventArgs ea)
		{
			IsUpToDate?.Invoke(null, ea);
		}
		public static event EventHandler<EventArgs> IsUpToDate;

		public static void OnUpdateSkipped(UpdateSkippedEventArgs usea)
		{
			UpdateSkipped?.Invoke(null, usea);
		}
		public static event EventHandler<UpdateSkippedEventArgs> UpdateSkipped;
	}

	public class UpdateFailedEventArgs : EventArgs
	{
		public Exception Exception { get; set; }
	}

	public class UpdateSkippedEventArgs : EventArgs
	{
		public string SkippedVersion { get; set; }
	}
}
