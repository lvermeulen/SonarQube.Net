namespace SonarQube.Net.Models
{
	public abstract class MetricBase : KeyedName
	{
		public string Description { get; set; }
		public string Domain { get; set; }
		public string Type { get; set; }
		public bool? Qualitative { get; set; }
		public bool? Hidden { get; set; }
		public bool? Custom { get; set; }
	}
}