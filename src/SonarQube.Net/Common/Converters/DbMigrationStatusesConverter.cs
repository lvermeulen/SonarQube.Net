using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class DbMigrationStatusesConverter : JsonEnumConverter<DbMigrationStatuses>
	{
		public override Dictionary<DbMigrationStatuses, string> Map { get; } = new Dictionary<DbMigrationStatuses, string>
		{
			[DbMigrationStatuses.NoMigration] = "NO_MIGRATION",
			[DbMigrationStatuses.NotSupported] = "NOT_SUPPORTED",
			[DbMigrationStatuses.MigrationRunning] = "MIGRATION_RUNNING",
			[DbMigrationStatuses.MigrationSucceeded] = "MIGRATION_SUCCEEDED",
			[DbMigrationStatuses.MigrationFailed] = "MIGRATION_FAILED",
			[DbMigrationStatuses.MigrationRequired] = "MIGRATION_REQUIRED"
		};

		public override string Description { get; } = "db migration status";
	}
}
