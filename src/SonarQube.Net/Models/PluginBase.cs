namespace SonarQube.Net.Models
{
	public abstract class PluginBase : KeyName
	{
		public string Category { get; set; }
		public string Description { get; set; }
		public string License { get; set; }
		public string OrganizationName { get; set; }
		public string OrganizationUrl { get; set; }
	}
}