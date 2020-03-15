using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class WebServiceParameter
	{
		public string Key { get; set; }
		public bool Required { get; set; }
		public bool Internal { get; set; }
		public int MaximumValue { get; set; }
		public int MaximumLength { get; set; }
		public int MinimumLength { get; set; }
		public string Description { get; set; }
		public string DefaultValue { get; set; }
		public string ExampleValue { get; set; }
		public string Since { get; set; }
		public string DeprecatedSince { get; set; }
		public string DeprecatedKey { get; set; }
		public string DeprecatedKeySince { get; set; }
		public IEnumerable<string> PossibleValues { get; set; }
	}
}