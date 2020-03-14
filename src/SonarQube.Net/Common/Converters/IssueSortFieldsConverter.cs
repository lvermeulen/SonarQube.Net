using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueSortFieldsConverter : JsonEnumConverter<IssueSortFields>
	{
		public static IssueSortFieldsConverter Instance { get; } = new IssueSortFieldsConverter();

		public static string ToString(IssueSortFields value) => Instance.ConvertToString(value);

		public override Dictionary<IssueSortFields, string> Map { get; } = new Dictionary<IssueSortFields, string>
		{
			[IssueSortFields.CreationDate] = "CREATION_DATE",
			[IssueSortFields.UpdateDate] = "UPDATE_DATE",
			[IssueSortFields.CloseDate] = "CLOSE_DATE",
			[IssueSortFields.Assignee] = "ASSIGNEE",
			[IssueSortFields.Severity] = "SEVERITY",
			[IssueSortFields.Status] = "STATUS",
			[IssueSortFields.FileLine] = "FILE_LINE",
			[IssueSortFields.Hotspots] = "HOTSPOTS"
		};

		public override string Description { get; } = "issue sort field";
	}
}
