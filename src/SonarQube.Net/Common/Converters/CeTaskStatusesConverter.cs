using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class CeTaskStatusesConverter : JsonEnumConverter<CeTaskStatuses>
	{
		public static CeTaskStatusesConverter Instance { get; } = new CeTaskStatusesConverter();

		public static string ToString(CeTaskStatuses value) => Instance.ConvertToString(value);

		public override Dictionary<CeTaskStatuses, string> Map { get; } = new Dictionary<CeTaskStatuses, string>
		{
			[CeTaskStatuses.Success] = "SUCCESS",
			[CeTaskStatuses.Failed] = "FAILED",
			[CeTaskStatuses.Canceled] = "CANCELED",
			[CeTaskStatuses.Pending] = "PENDING",
			[CeTaskStatuses.InProgress] = "IN_PROGRESS"
		};

		public override string Description => "ce task status";
	}
}
