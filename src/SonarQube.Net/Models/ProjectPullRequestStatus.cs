namespace SonarQube.Net.Models
{
	public class ProjectPullRequestStatus
	{
		public string QualityGateStatus { get; set; }
		public int? Bugs { get; set; }
		public int? Vulnerabilities { get; set; }
		public int? CodeSmells { get; set; }
	}
}