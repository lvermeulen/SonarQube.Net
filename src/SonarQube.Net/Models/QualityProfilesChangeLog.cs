using System;

namespace SonarQube.Net.Models
{
	public class QualityProfilesChangeLog
	{
		public DateTime? Date { get; set; }
		public string Action { get; set; }
		public string AuthorLogin { get; set; }
		public string AuthorName { get; set; }
		public string RuleKey { get; set; }
		public string RuleName { get; set; }
		public SeverityFormat Params { get; set; }
	}
}
