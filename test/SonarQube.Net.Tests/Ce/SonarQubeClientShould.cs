using System.Linq;
using System.Threading.Tasks;
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

		[Theory]
		[InlineData("HelloWorld")]
		public async Task GetCeComponentAsync(string component)
		{
			var result = await _client.GetCeComponentAsync(component).ConfigureAwait(false);
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
