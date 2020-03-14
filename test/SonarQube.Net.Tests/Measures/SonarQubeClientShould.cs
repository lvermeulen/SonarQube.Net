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
		public async Task GetMeasuresComponentAsync()
		{
			var results = await _client.SearchIssuesAsync().ConfigureAwait(false);
			var firstResult = results.Components.FirstOrDefault(x => x.Qualifier == ComponentQualifiers.Fil);
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetMeasuresComponentAsync(firstResult.Key, new[] { "violations" }).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetMeasuresComponentTreeAsync()
		{
			var results = await _client.SearchIssuesAsync().ConfigureAwait(false);
			var firstResult = results.Components.FirstOrDefault(x => x.Qualifier == ComponentQualifiers.Trk);
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetMeasuresComponentTreeAsync(firstResult.Key, new[] { "violations" }).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchMeasuresHistoryAsync()
		{
			var results = await _client.SearchIssuesAsync().ConfigureAwait(false);
			var firstResult = results.Components.FirstOrDefault(x => x.Qualifier == ComponentQualifiers.Trk);
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.SearchMeasuresHistoryAsync(firstResult.Key, new[] { "violations" }).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
