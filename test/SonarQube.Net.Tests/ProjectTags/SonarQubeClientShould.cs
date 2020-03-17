using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task SearchProjectTagsAsync()
        {
            var result = await _client.SearchProjectTagsAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
