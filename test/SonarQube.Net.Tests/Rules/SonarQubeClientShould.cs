using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetRuleRepositoriesAsync()
		{
			var result = await _client.GetRuleRepositoriesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchRulesAsync()
		{
			var result = await _client.SearchRulesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShowRuleAsync()
		{
			var results = await _client.SearchRulesAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.ShowRuleAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetRuleTagsAsync()
		{
			var result = await _client.GetRuleTagsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
