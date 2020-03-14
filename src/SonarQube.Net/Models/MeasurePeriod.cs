using System;

namespace SonarQube.Net.Models
{
	public class MeasurePeriod
	{
		public string Mode { get; set; }
		public DateTime? Date { get; set; }
		public string Parameter { get; set; }
	}
}