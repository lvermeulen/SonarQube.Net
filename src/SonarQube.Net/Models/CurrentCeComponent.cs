using System;

namespace SonarQube.Net.Models
{
	public class CurrentCeComponent
	{
		public string Organization { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public string ComponentId { get; set; }
		public string ComponentKey { get; set; }
		public string ComponentName { get; set; }
		public string ComponentQualifier { get; set; }
		public string AnalysisId { get; set; }
		public string Status { get; set; }
		public DateTime? SubmittedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? FinishedAt { get; set; }
		public int ExecutionTimeMs { get; set; }
		public bool Logs { get; set; }
		public string ErrorMessage { get; set; }
		public string ErrorType { get; set; }
		public bool HasErrorStacktrace { get; set; }
		public bool HasScannerContext { get; set; }
	}
}