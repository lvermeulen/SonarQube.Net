using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueStatusesConverter : JsonEnumConverter<IssueStatuses>
	{
		public static IssueStatusesConverter Instance { get; } = new IssueStatusesConverter();

		public static string ToString(IssueStatuses value) => Instance.ConvertToString(value);

		public override Dictionary<IssueStatuses, string> Map { get; } = new Dictionary<IssueStatuses, string>
		{
			[IssueStatuses.Open] = "OPEN",
			[IssueStatuses.Confirmed] = "CONFIRMED",
			[IssueStatuses.Reopened] = "REOPENED",
			[IssueStatuses.Resolved] = "RESOLVED",
			[IssueStatuses.Closed] = "CLOSED"
		};

		public override string Description => "issue status";
	}
}
