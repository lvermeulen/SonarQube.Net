using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task SearchFavoritesAsync()
        {
            var result = await _client.SearchFavoritesAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
