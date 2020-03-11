using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task SearchPermissionTemplatesAsync()
        {
            var result = await _client.SearchPermissionTemplatesAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
