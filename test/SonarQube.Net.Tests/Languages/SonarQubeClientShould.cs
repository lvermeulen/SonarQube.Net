using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task GetLanguagesListAsync()
        {
            var result = await _client.GetLanguagesListAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
