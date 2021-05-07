using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class AvailableIssueFieldsConverter : JsonEnumConverter<AvailableIssueFields>
	{
		public static AvailableIssueFieldsConverter Instance { get; } = new AvailableIssueFieldsConverter();

		public static string ToString(AvailableIssueFields value) => Instance.ConvertToString(value);

		public override Dictionary<AvailableIssueFields, string> Map { get; } = new Dictionary<AvailableIssueFields, string>
		{
			[AvailableIssueFields.All] = "_all",
			[AvailableIssueFields.Comments] = "comments",
			[AvailableIssueFields.Languages] = "languages",
			[AvailableIssueFields.ActionPlans] = "actionPlans",
			[AvailableIssueFields.Rules] = "rules",
			[AvailableIssueFields.Transitions] = "transitions",
			[AvailableIssueFields.Actions] = "actions",
			[AvailableIssueFields.Users] = "users"
		};

		public override string Description => "available issue field";
	}
}
