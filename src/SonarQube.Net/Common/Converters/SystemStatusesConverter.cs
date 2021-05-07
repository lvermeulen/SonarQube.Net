using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SystemStatusesConverter : JsonEnumConverter<SystemStatuses>
	{
		public override Dictionary<SystemStatuses, string> Map { get; } = new Dictionary<SystemStatuses, string>
		{
			[SystemStatuses.Starting] = "STARTING",
			[SystemStatuses.Up] = "UP",
			[SystemStatuses.Down] = "DOWN",
			[SystemStatuses.Restarting] = "RESTARTING",
			[SystemStatuses.DbMigrationNeeded] = "DB_MIGRATION_NEEDED",
			[SystemStatuses.DbMigrationRunning] = "DB_MIGRATION_RUNNING"
		};

		public override string Description => "system status";
	}
}
