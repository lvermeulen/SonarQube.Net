using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityGateRef
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<QualityGateConditionRef> Conditions { get; set; }
		public bool? IsBuiltIn { get; set; }
		public IDictionary<string, bool?> Actions { get; set; }
	}
}
