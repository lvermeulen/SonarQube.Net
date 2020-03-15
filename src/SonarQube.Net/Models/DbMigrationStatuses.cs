namespace SonarQube.Net.Models
{
	public enum DbMigrationStatuses
	{
		NoMigration,
		NotSupported,
		MigrationRunning,
		MigrationSucceeded,
		MigrationFailed,
		MigrationRequired
	}
}
