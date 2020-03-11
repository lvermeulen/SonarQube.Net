using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class DefaultPermissionTemplate
	{
		public string TemplateId { get; set; }

		[JsonConverter(typeof(ComponentQualifiersConverter))]
		public ComponentQualifiers Qualifier { get; set; }
	}
}