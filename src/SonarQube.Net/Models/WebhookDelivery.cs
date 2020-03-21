using System;

namespace SonarQube.Net.Models
{
	public class WebhookDelivery
	{
		public string Id { get; set; }
		public string ComponentKey { get; set; }
		public string CeTaskId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public DateTime? At { get; set; }
		public bool? Success { get; set; }
		public int? HttpStatus { get; set; }
		public int? DurationMs { get; set; }
		public string Payload { get; set; }
	}
}
