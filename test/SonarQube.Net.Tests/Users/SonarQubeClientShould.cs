using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetUserGroupsAsync()
		{
			var results = await _client.SearchUsersAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetUserGroupsAsync(firstResult.Login).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task SearchUsersAsync()
		{
			var result = await _client.SearchUsersAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
