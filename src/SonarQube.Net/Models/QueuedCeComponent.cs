using System;

namespace SonarQube.Net.Models
{
	public class QueuedCeComponent
	{
		public string Organization { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public string ComponentId { get; set; }
		public string ComponentKey { get; set; }
		public string ComponentName { get; set; }
		public string ComponentQualifier { get; set; }
		public string Status { get; set; }
		public DateTime? SubmittedAt { get; set; }
		public bool Logs { get; set; }
	}
}