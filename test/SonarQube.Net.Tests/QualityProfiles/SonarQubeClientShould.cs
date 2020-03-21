using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task BackupQualityProfileAsync()
		{
			var result = await _client.BackupQualityProfileAsync("cs", "Sonar way").ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityProfileChangeLogsAsync()
		{
			var result = await _client.GetQualityProfileChangeLogsAsync("cs", "Sonar way").ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task ExportQualityProfileAsync()
		{
			var result = await _client.ExportQualityProfileAsync("cs").ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityProfileExportersAsync()
		{
			var result = await _client.GetQualityProfileExportersAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityProfileImportersAsync()
		{
			var result = await _client.GetQualityProfileImportersAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityProfileInheritanceAsync()
		{
			var result = await _client.GetQualityProfileInheritanceAsync("cs", "Sonar way").ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityProfileProjectsStatusAsync()
		{
			var results = await _client.SearchQualityProfilesAsync().ConfigureAwait(false);
			var firstResult = results.Profiles.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetQualityProfileProjectsStatusAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchQualityProfilesAsync()
		{
			var result = await _client.SearchQualityProfilesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
