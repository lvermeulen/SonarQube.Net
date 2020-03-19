namespace SonarQube.Net.Models
{
	public class QualityGateCondition
	{
		public string Status { get; set; }
		public string MetricKey { get; set; }
		public string Comparator { get; set; }
		public int? PeriodIndex { get; set; }
		public string ErrorThreshold { get; set; }
		public string ActualValue { get; set; }
	}
}