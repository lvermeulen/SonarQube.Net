using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetSystemDbMigrationStatusAsync()
		{
			var result = await _client.GetSystemDbMigrationStateAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSystemHealthAsync()
		{
			var result = await _client.GetSystemHealthAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSystemLogsAsync()
		{
			string result = await _client.GetSystemLogsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSystemPingAsync()
		{
			string result = await _client.GetSystemPingAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSystemStatusAsync()
		{
			var result = await _client.GetSystemStatusAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSystemUpgradesAsync()
		{
			var result = await _client.GetSystemUpgradesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
