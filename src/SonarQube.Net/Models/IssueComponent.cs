using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class IssueComponent : KeyedName
	{
		public bool? Enabled { get; set; }

		[JsonConverter(typeof(ComponentQualifiersConverter))]
		public ComponentQualifiers Qualifier { get; set; }

		public string LongName { get; set; }
		public string Path { get; set; }
	}
}