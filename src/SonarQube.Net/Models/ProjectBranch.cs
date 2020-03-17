using System;

namespace SonarQube.Net.Models
{
	public class ProjectBranch
	{
		public string Name { get; set; }
		public bool? IsMain { get; set; }
		public string Type { get; set; }
		public ProjectBranchStatus Status { get; set; }
		public DateTime? AnalysisDate { get; set; }
		public bool? ExcludedFromPurge { get; set; }
	}
}
