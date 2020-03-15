using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class SettingsDefinition : KeyedName
	{
		public string Description { get; set; }
		public string Type { get; set; }
		public string Category { get; set; }
		public string SubCategory { get; set; }
		public bool MultiValues { get; set; }
		public string DefaultValue { get; set; }
		public IEnumerable<string> Options { get; set; }
		public IEnumerable<Field> Fields { get; set; }
	}
}
