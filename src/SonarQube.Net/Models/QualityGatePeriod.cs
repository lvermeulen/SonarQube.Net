using System;

namespace SonarQube.Net.Models
{
	public class QualityGatePeriod
	{
		public int? Index { get; set; }
		public string Mode { get; set; }
		public DateTime? Date { get; set; }
		public string Parameter { get; set; }
	}
}