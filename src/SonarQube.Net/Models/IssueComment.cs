using System;

namespace SonarQube.Net.Models
{
	public class IssueComment
	{
		public string Key { get; set; }
		public string Login { get; set; }
		public string HtmlText { get; set; }
		public string Markdown { get; set; }
		public bool? Updatable { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}