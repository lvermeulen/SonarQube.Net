namespace SonarQube.Net.Models
{
	public class Metric : KeyedName
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public string Domain { get; set; }
		public string Type { get; set; }
		public int Direction { get; set; }
		public bool Qualitative { get; set; }
		public bool Hidden { get; set; }
		public bool Custom { get; set; }
	}
}
