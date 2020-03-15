using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class Issue
	{
		public string Key { get; set; }
		public string Component { get; set; }
		public string Project { get; set; }
		public string Rule { get; set; }

		[JsonConverter(typeof(IssueStatusesConverter))]
		public IssueStatuses Status { get; set; }

		[JsonConverter(typeof(IssueResolutionsConverter))]
		public IssueResolutions Resolution { get; set; }

		[JsonConverter(typeof(SeveritiesConverter))]
		public Severities Severity { get; set; }

		public string Message { get; set; }
		public int Line { get; set; }
		public string Hash { get; set; }
		public string Author { get; set; }
		public string Effort { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public IEnumerable<string> Tags { get; set; }

		[JsonConverter(typeof(IssueTypesConverter))]
		public IssueTypes Type { get; set; }

		public IEnumerable<IssueComment> Comments { get; set; }
		public IDictionary<string, string> Attr { get; set; }
		public IEnumerable<string> Transitions { get; set; }
		public IEnumerable<string> Actions { get; set; }
		public TextRange TextRange { get; set; }
		public IEnumerable<Flow> Flows { get; set; }
	}
}