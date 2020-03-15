using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetSettingsDefinitionsListAsync()
		{
			var result = await _client.GetSettingsDefinitionsListAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetSettingsValuesAsync()
		{
			var result = await _client.GetSettingsValuesAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
