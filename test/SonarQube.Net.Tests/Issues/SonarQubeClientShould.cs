using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetIssueAuthors()
		{
			var result = await _client.GetIssueAuthorsAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetIssueChangeLogsAsync()
		{
			var results = await _client.SearchIssuesAsync().ConfigureAwait(false);
			var firstResult = results.Issues?.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetIssueChangeLogsAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchIssuesAsync()
		{
			var result = await _client.SearchIssuesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
