using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Theory]
		[InlineData("Test")]
		public async Task GetNewCodePeriodsListAsync(string project)
		{
			var result = await _client.GetNewCodePeriodsListAsync(project: project).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("Test")]
		public async Task ShowNewCodePeriodAsync(string project)
		{
			var result = await _client.ShowNewCodePeriodAsync(project: project).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
