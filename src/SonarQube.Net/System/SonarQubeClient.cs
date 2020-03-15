using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetSystemUrl() => GetBaseUrl("/api/system");

		private IFlurlRequest GetSystemUrl(string path) => GetSystemUrl().AppendPathSegment(path);

		public async Task<bool> ChangeSystemLogLevelAsync(LogLevels level)
		{
			var response = await GetSystemUrl("change_log_level")
				.SetQueryParam(nameof(level), LogLevelsConverter.ToString(level))
				.PostJsonAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<DbMigrationState> GetSystemDbMigrationStateAsync()
		{
			return await GetSystemUrl("db_migration_status")
				.GetJsonAsync<DbMigrationState>()
				.ConfigureAwait(false);
		}

		public async Task<SystemHealth> GetSystemHealthAsync()
		{
			return await GetSystemUrl("health")
				.GetJsonAsync<SystemHealth>()
				.ConfigureAwait(false);
		}

		public async Task<string> GetSystemLogsAsync(SystemProcessTypes? process = null)
		{
			return await GetSystemUrl("logs")
				.SetQueryParam(nameof(process), SystemProcessTypesToStringConverter.ToString(process))
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<DbMigrationState> MigrateDbAsync()
		{
			var response = await GetSystemUrl("migrate_db")
				.PostJsonAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<DbMigrationState>(response).ConfigureAwait(false);
		}

		public async Task<string> GetSystemPingAsync()
		{
			return await GetSystemUrl("ping")
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> RestartServerAsync()
		{
			var response = await GetSystemUrl("restart")
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<SystemStatus> GetSystemStatusAsync()
		{
			return await GetSystemUrl("status")
				.GetJsonAsync<SystemStatus>()
				.ConfigureAwait(false);
		}

		public async Task<SystemUpgrades> GetSystemUpgradesAsync()
		{
			return await GetSystemUrl("upgrades")
				.GetJsonAsync<SystemUpgrades>()
				.ConfigureAwait(false);
		}
	}
}
