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
		public async Task GetCeActivityAsync()
		{
			var result = await _client.GetCeActivityAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetCeActivityStatusAsync()
		{
			var results = await _client.GetCeActivityAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetCeActivityStatusAsync(firstResult.ComponentId).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetCeComponentAsync()
		{
			var results = await _client.SearchComponentsAsync(new[] { ComponentQualifiers.Trk }).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetCeComponentAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetCeTaskAsync()
		{
			var results = await _client.GetCeActivityAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetCeTaskAsync(firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
