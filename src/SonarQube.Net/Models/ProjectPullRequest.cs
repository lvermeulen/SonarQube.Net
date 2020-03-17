using System;

namespace SonarQube.Net.Models
{
	public class ProjectPullRequest
	{
		public string Key { get; set; }
		public string Title { get; set; }
		public string Branch { get; set; }
		public string Base { get; set; }
		public ProjectPullRequestStatus Status { get; set; }
		public DateTime? AnalysisDate { get; set; }
		public string Url { get; set; }
		public string Target { get; set; }
	}
}
