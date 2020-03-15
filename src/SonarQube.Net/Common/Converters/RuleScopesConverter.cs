using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RuleScopesConverter : JsonEnumConverter<RuleScopes>
	{
		public override Dictionary<RuleScopes, string> Map { get; } = new Dictionary<RuleScopes, string>
		{
			[RuleScopes.Main] = "MAIN"
		};

		public override string Description { get; } = "rule scope";
	}
}
