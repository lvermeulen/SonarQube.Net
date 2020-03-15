namespace SonarQube.Net.Models
{
	public class RequireUpdatePlugin : PluginBase
	{
		public bool? EditionBundled { get; set; }
		public string TermsAndConditionsUrl { get; set; }
		public string Version { get; set; }
	}
}