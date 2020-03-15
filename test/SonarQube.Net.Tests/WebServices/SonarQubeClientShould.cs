using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetWebServicesListAsync()
		{
			var result = await _client.GetWebServicesListAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetWebServiceResponseExampleAsync()
		{
			var results = await _client.GetWebServicesListAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault(x => x.Path == "api/issues");
			if (firstResult == null)
			{
				return;
			}

			var action = firstResult.Actions.FirstOrDefault(x => !x.Post)?.Key;
			var result = await _client.GetWebServiceResponseExampleAsync(action, firstResult.Path).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
