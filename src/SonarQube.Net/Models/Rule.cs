using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class Rule : IssueRule
	{
		public string Repo { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string HtmlDesc { get; set; }
		public string MdDesc { get; set; }

		[JsonConverter(typeof(SeveritiesConverter))]
		public Severities Severity { get; set; }

		public bool IsTemplate { get; set; }
		public string TemplateKey { get; set; }
		public IEnumerable<object> SysTags { get; set; }
		public IEnumerable<RuleParameter> Params { get; set; }
		public string Scope { get; set; }
		public bool IsExternal { get; set; }

		[JsonConverter(typeof(IssueTypesConverter))]
		public IssueTypes Type { get; set; }
	}
}
