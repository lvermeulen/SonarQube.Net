using System.Linq;
using System.Threading.Tasks;
using SonarQube.Net.Models;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GenerateMeasureBadgeAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GenerateMeasureBadgeAsync(firstResult.Key, BadgeMetricTypes.Bugs).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GenerateQualityGateBadgeAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GenerateQualityGateBadgeAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
