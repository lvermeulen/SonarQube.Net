using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class NotificationTypesConverter : JsonEnumConverter<NotificationTypes>
	{
		public static NotificationTypesConverter Instance { get; } = new NotificationTypesConverter();

		public static string ToString(NotificationTypes value) => Instance.ConvertToString(value);

		public static string ToString(NotificationTypes? value) => value.HasValue
			? Instance.ConvertToString(value.Value)
			: null;

		public override Dictionary<NotificationTypes, string> Map { get; } = new Dictionary<NotificationTypes, string>
		{
			[NotificationTypes.CeReportTaskFailure] = "CeReportTaskFailure",
			[NotificationTypes.ChangesOnMyIssue] = "ChangesOnMyIssue",
			[NotificationTypes.NewAlerts] = "NewAlerts",
			[NotificationTypes.SqMyNewIssues] = "SQ-MyNewIssues",
			[NotificationTypes.NewFalsePositiveIssue] = "NewFalsePositiveIssue",
			[NotificationTypes.NewIssues] = "NewIssues"
		};

		public override string Description => "notification type";
	}
}
