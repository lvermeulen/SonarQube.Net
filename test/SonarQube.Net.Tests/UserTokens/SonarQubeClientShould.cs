using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task SearchUserTokensAsync()
        {
            var result = await _client.SearchUserTokensAsync("luk.vermeulen").ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
