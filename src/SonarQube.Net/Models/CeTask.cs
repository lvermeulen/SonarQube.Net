using System;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class CeTask
	{
		public string Organization { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public string ComponentId { get; set; }
		public string ComponentKey { get; set; }
		public string ComponentName { get; set; }
		public string ComponentQualifier { get; set; }
		public string AnalysisId { get; set; }

		[JsonConverter(typeof(CeTaskStatusesConverter))]
		public CeTaskStatuses Status { get; set; }

		public DateTime? SubmittedAt { get; set; }
		public string SubmitterLogin { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? ExecutedAt { get; set; }
		public int ExecutionTimeMs { get; set; }
		public bool Logs { get; set; }
		public bool HasErrorStacktrace { get; set; }
		public bool HasScannerContext { get; set; }
	}
}
