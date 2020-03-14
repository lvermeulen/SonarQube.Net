namespace SonarQube.Net.Models
{
	public class Metric : MetricBase
	{
		public string Id { get; set; }
		public int Direction { get; set; }
	}
}
