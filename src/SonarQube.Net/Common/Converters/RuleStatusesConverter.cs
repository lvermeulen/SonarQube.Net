using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RuleStatusesConverter : JsonEnumConverter<RuleStatuses>
	{
		public override Dictionary<RuleStatuses, string> Map { get; } = new Dictionary<RuleStatuses, string>
		{
			[RuleStatuses.Ready] = "READY"
		};

		public override string Description { get; } = "rule status";
	}
}
