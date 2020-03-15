using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class Field : KeyedName
	{
		public string Description { get; set; }
		public string Type { get; set; }
		public IEnumerable<string> Options { get; set; }
	}
}