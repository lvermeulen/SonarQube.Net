namespace SonarQube.Net.Models
{
	public class QualityProfileProjectStatus : KeyedName
	{
		public string Id { get; set; }
		public bool? Selected { get; set; }
	}
}
