using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class Notification
	{
		public string Channel { get; set; }

		[JsonConverter(typeof(NotificationTypesConverter))]
		public NotificationTypes Type { get; set; }

		public string Organization { get; set; }
		public string Project { get; set; }
		public string ProjectName { get; set; }
	}
}