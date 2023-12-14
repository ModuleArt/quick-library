using Octokit;
using System;
using System.Threading.Tasks;

namespace QuickLibrary
{
	internal static class UpdateChecker
	{
		private static IReleasesClient _releaseClient;
		internal static GitHubClient Github;

		internal static string CurrentVersion;
		internal static string RepositoryOwner;
		internal static string RepostoryName;
		internal static Release LatestRelease;

		internal static void Init(string owner, string repo)
		{
			string version = System.Windows.Forms.Application.ProductVersion;

			Github = new GitHubClient(new ProductHeaderValue(repo + @"-UpdateCheck"));
			_releaseClient = Github.Repository.Release;

			RepositoryOwner = owner;
			RepostoryName = repo;
			CurrentVersion = version;
		}

		internal static async Task<string> CheckUpdate()
		{
			var releases = await _releaseClient.GetAll(RepositoryOwner, RepostoryName);
			LatestRelease = releases[0];

			string[] curDots = CurrentVersion.Split('.');
			int curMajor = Convert.ToInt32(curDots[0]);
			int curMinor = Convert.ToInt32(curDots[1]);
			int curPatch = Convert.ToInt32(curDots[2]);

			for (int i = 0; i < releases.Count; i++)
			{
				string[] dots = releases[i].TagName.Substring(1, releases[i].TagName.Length - 1).Split('.');
				int major = Convert.ToInt32(dots[0]);
				int minor = Convert.ToInt32(dots[1]);
				int patch = Convert.ToInt32(dots[2]);

				if (major > curMajor)
				{
					return major + "." + minor + "." + patch;
				}
				else if (major == curMajor)
				{
					if (minor > curMinor)
					{
						return major + "." + minor + "." + patch;
					}
					else if (minor == curMinor)
					{
						if (patch > curPatch)
						{
							return major + "." + minor + "." + patch;
						}
					}
				}
			}
			return null;
		}

		internal static async Task<string> RenderReleaseNotes()
		{
			if (LatestRelease == null)
			{
				throw new InvalidOperationException();
			}
			return await Github.Miscellaneous.RenderRawMarkdown(LatestRelease.Body);
		}

		internal static string GetAssetUrl(string assetname)
		{
			const string template = "https://github.com/{0}/{1}/releases/download/{2}/{3}";
			return string.Format(template, RepositoryOwner, RepostoryName, LatestRelease.TagName, assetname);
		}
	}
}
