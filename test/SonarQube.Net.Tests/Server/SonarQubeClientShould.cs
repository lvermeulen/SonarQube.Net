using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task GetServerVersionAsync()
        {
            var result = await _client.GetServerVersionAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
