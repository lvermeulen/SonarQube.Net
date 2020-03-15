namespace SonarQube.Net.Models
{
	public class SystemUpgrade
	{
		public string Version { get; set; }
		public string Description { get; set; }
		public string ReleaseDate { get; set; }
		public string ChangeLogUrl { get; set; }
		public string DownloadUrl { get; set; }
		public UpgradePlugins Plugins { get; set; }
	}
}