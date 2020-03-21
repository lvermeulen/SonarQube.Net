using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class SystemStatus
	{
		public string Id { get; set; }
		public string Version { get; set; }

		[JsonConverter(typeof(SystemStatusesConverter))]
		public SystemStatuses Status { get; set; }
	}
}
