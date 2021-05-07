using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueResolutionsConverter : JsonEnumConverter<IssueResolutions>
	{
		public static IssueResolutionsConverter Instance { get; } = new IssueResolutionsConverter();

		public static string ToString(IssueResolutions value) => Instance.ConvertToString(value);

		public override Dictionary<IssueResolutions, string> Map { get; } = new Dictionary<IssueResolutions, string>
		{
			[IssueResolutions.FalsePositive] = "FALSE-POSITIVE",
			[IssueResolutions.WontFix] = "WONTFIX",
			[IssueResolutions.Fixed] = "FIXED",
			[IssueResolutions.Removed] = "REMOVED"
		};

		public override string Description => "issue resolution";
	}
}
