using System;
using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class IssueChangeLog
	{
		public string User { get; set; }
		public string UserName { get; set; }
		public bool IsUserActive { get; set; }
		public string Avatar { get; set; }
		public DateTime? CreationDate { get; set; }
		public IEnumerable<IssueDiff> Diffs { get; set; }
	}
}
