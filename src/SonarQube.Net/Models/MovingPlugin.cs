namespace SonarQube.Net.Models
{
	public class MovingPlugin : PluginBase
	{
		public string Version { get; set; }
		public string HomepageUrl { get; set; }
		public string IssueTrackerUrl { get; set; }
		public string ImplementationBuild { get; set; }
		public string DocumentationPath { get; set; }
	}
}