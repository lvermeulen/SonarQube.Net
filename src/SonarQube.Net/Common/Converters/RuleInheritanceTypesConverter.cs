using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RuleInheritanceTypesConverter : JsonEnumConverter<RuleInheritanceTypes>
	{
		public static RuleInheritanceTypesConverter Instance { get; } = new RuleInheritanceTypesConverter();

		public static string ToString(RuleInheritanceTypes value) => Instance.ConvertToString(value);

		public static string ToString(RuleInheritanceTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<RuleInheritanceTypes, string> Map { get; } = new Dictionary<RuleInheritanceTypes, string>
		{
			[RuleInheritanceTypes.None] = "NONE",
			[RuleInheritanceTypes.Inherited] = "INHERITED",
			[RuleInheritanceTypes.Overrides] = "OVERRIDES"
		};

		public override string Description => "rule inheritance type";
	}
}
