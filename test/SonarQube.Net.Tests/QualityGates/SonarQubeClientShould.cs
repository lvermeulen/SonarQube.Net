using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetProjectQualityGateAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetProjectQualityGateAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityGatesListAsync()
		{
			var result = await _client.GetQualityGatesListAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetQualityGatesProjectStatusAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetQualityGatesProjectStatusAsync(projectKey: firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchQualityGatesAsync()
		{
			var results = await _client.GetQualityGatesListAsync().ConfigureAwait(false);
			var firstResult = results.Qualitygates.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.SearchQualityGatesAsync(firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShowQualityGateAsync()
		{
			var results = await _client.GetQualityGatesListAsync().ConfigureAwait(false);
			var firstResult = results.Qualitygates.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.ShowQualityGateAsync(firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
