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
		public async Task ShowDuplicationsAsync()
		{
			var results = await _client.SearchIssuesAsync().ConfigureAwait(false);
			var firstResult = results.Components.FirstOrDefault(x => x.Qualifier == ComponentQualifiers.Fil);
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.ShowDuplicationsAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
