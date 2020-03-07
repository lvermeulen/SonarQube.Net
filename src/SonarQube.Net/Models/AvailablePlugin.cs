namespace SonarQube.Net.Models
{
	public class AvailablePlugin : PluginBase
	{
		public string TermsAndConditionsUrl { get; set; }
		public bool? EditionBundled { get; set; }
		public PluginRelease Release { get; set; }
		public PluginUpdate Update { get; set; }
	}
}
