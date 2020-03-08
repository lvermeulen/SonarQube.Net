using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task SearchProjectsAsync()
        {
            var result = await _client.SearchProjectsAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
