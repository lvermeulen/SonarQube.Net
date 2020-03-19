using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityGatesProjectStatus
	{
		public string Status { get; set; }
		public bool? IgnoredConditions { get; set; }
		public IEnumerable<QualityGateCondition> Conditions { get; set; }
		public IEnumerable<QualityGatePeriod> Periods { get; set; }
	}
}
