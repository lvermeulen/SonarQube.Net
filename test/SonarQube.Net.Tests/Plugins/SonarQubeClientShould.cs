using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetAvailablePluginsAsync()
		{
			var result = await _client.GetAvailablePluginsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetInstalledPluginsAsync()
		{
			var result = await _client.GetInstalledPluginsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetPendingPluginsAsync()
		{
			var result = await _client.GetPendingPluginsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetUpdatedPluginsAsync()
		{
			var result = await _client.GetUpdatedPluginsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
