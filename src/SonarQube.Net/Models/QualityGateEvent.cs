using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityGateEvent
	{
		public string Status { get; set; }
		public bool? StillFailing { get; set; }
		public IEnumerable<Failing> Failing { get; set; }
	}
}