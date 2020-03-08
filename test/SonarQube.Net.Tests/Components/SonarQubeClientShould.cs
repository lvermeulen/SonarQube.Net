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
		public async Task SearchComponentsAsync()
		{
			var result = await _client.SearchComponentsAsync(new[] { ComponentQualifiers.Trk }).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShowComponentAsync()
		{
			var results = await _client.SearchComponentsAsync(new[] { ComponentQualifiers.Trk }).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.ShowComponentAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetComponentsTreeAsync()
		{
			var results = await _client.SearchComponentsAsync(new[] { ComponentQualifiers.Trk }).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetComponentsTreeAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
