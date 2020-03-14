using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueTypesConverter : JsonEnumConverter<IssueTypes>
	{
		public static IssueTypesConverter Instance { get; } = new IssueTypesConverter();

		public static string ToString(IssueTypes value) => Instance.ConvertToString(value);

		public static string ToString(IssueTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<IssueTypes, string> Map { get; } = new Dictionary<IssueTypes, string>
		{
			[IssueTypes.CodeSmell] = "CODE_SMELL",
			[IssueTypes.Bug] = "BUG",
			[IssueTypes.Vulnerability] = "VULNERABILITY"
		};

		public override string Description { get; } = "issue type";
	}
}
