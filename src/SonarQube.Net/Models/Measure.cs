namespace SonarQube.Net.Models
{
	public class Measure
	{
		public string Metric { get; set; }
		public string Value { get; set; }
		public MeasurePeriodValue Period { get; set; }
	}
}