using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RuleSortFieldsConverter : JsonEnumConverter<RuleSortFields>
	{
		public static RuleSortFieldsConverter Instance { get; } = new RuleSortFieldsConverter();

		public static string ToString(RuleSortFields value) => Instance.ConvertToString(value);

		public static string ToString(RuleSortFields? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<RuleSortFields, string> Map { get; } = new Dictionary<RuleSortFields, string>
		{
			[RuleSortFields.Name] = "name",
			[RuleSortFields.UpdatedAt] = "updatedAt",
			[RuleSortFields.CreatedAt] = "createdAt",
			[RuleSortFields.Key] = "key"
		};

		public override string Description => "rule sort field";
	}
}
