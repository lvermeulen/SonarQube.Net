using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class NotificationsList
	{
		public IEnumerable<Notification> Notifications { get; set; }
		public IEnumerable<string> Channels { get; set; }

		[JsonConverter(typeof(NotificationTypesConverter))]
		public IEnumerable<NotificationTypes> GlobalTypes { get; set; }

		[JsonConverter(typeof(NotificationTypesConverter))]
		public IEnumerable<NotificationTypes> PerProjectTypes { get; set; }
	}
}
