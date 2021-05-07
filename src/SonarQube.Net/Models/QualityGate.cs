using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityGate
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public bool? IsDefault { get; set; }
		public bool? IsBuiltIn { get; set; }
		public IDictionary<string, bool?> Actions { get; set; }
	}
}