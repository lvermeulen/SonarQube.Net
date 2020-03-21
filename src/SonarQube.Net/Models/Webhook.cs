namespace SonarQube.Net.Models
{
	public class Webhook : KeyedName
	{
		public string Url { get; set; }
		public string Secret { get; set; }
	}
}
