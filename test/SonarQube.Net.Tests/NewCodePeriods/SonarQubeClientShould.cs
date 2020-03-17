using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetNewCodePeriodsListAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetNewCodePeriodsListAsync(firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShowNewCodePeriodAsync()
		{
			var results = await _client.SearchProjectsAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.ShowNewCodePeriodAsync(project: firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
