using System.Windows.Forms;

namespace QuickLibrary
{
	public static class UpdateManager
	{
		public static async void checkForUpdates(bool showUpToDateDialog, bool darkMode, bool topMost, 
			string githubOwner, string githubRepository, string appName, string installFileName)
		{
			try
			{
				UpdateChecker checker = new UpdateChecker(githubOwner, githubRepository);

				bool update = await checker.CheckUpdate();

				if (update == false)
				{
					if (showUpToDateDialog)
					{
						MessageBox.Show("Application is up to date", "Updator", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					UpdateForm updateDialog = new UpdateForm(checker, appName, darkMode);
					updateDialog.TopMost = topMost;

					DialogResult result = updateDialog.ShowDialog();
					if (result == DialogResult.Yes)
					{
						DownloadForm downloadBox = new DownloadForm(checker.GetAssetUrl(installFileName), darkMode);
						downloadBox.TopMost = topMost;
						downloadBox.ShowDialog();
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
					MessageBox.Show("Connection error", "Updator", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
