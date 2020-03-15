using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RuleStatusesConverter : JsonEnumConverter<RuleStatuses>
	{
		public static RuleStatusesConverter Instance { get; } = new RuleStatusesConverter();

		public static string ToString(RuleStatuses value) => Instance.ConvertToString(value);

		public static string ToString(RuleStatuses? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<RuleStatuses, string> Map { get; } = new Dictionary<RuleStatuses, string>
		{
			[RuleStatuses.Beta] = "BETA",
			[RuleStatuses.Deprecated] = "DEPRECATED",
			[RuleStatuses.Ready] = "READY",
			[RuleStatuses.Removed] = "REMOVED"
		};

		public override string Description { get; } = "rule status";
	}
}
