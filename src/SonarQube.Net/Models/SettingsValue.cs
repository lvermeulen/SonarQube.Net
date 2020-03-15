using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class SettingsValue
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public bool? Inherited { get; set; }
		public IEnumerable<string> Values { get; set; }
		public IEnumerable<FieldValue> FieldValues { get; set; }
	}
}
