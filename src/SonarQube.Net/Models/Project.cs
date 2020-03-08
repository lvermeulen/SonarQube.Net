using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class Project : KeyedName
	{
		[JsonConverter(typeof(ProjectQualifiersConverter))]
		public ProjectQualifiers Qualifier { get; set; }
	}

}
