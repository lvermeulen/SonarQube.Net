using System.Collections.Generic;
using SonarQube.Net.Common.Models;

namespace SonarQube.Net.Models
{
	public class IssuesList
	{
		public Paging Paging { get; set; }
		public IEnumerable<Issue> Issues { get; set; }
		public IEnumerable<IssueComponent> Components { get; set; }
		public IEnumerable<IssueRule> Rules { get; set; }
		public IEnumerable<User> Users { get; set; }
	}
}
