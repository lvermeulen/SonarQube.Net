using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task SearchMetricsAsync()
		{
			var result = await _client.SearchMetricsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetMetricTypesAsync()
		{
			var result = await _client.GetMetricTypesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
