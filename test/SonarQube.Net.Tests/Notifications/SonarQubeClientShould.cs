using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task GetNotificationsListAsync()
        {
            var result = await _client.GetNotificationsListAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
