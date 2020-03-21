using System;
using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class FullQualityProfile : QualityProfileBase
	{
		public string LanguageName { get; set; }
		public bool? IsBuiltIn { get; set; }
		public int? ActiveRuleCount { get; set; }
		public int? ActiveDeprecatedRuleCount { get; set; }
		public DateTime? RuleUpdatedAt { get; set; }
		public DateTime? LastUsed { get; set; }
		public IDictionary<string, bool?> Actions { get; set; }
		public string ParentKey { get; set; }
		public string ParentName { get; set; }
		public int? ProjectCount { get; set; }
		public DateTime? UserUpdatedAt { get; set; }
	}
}
