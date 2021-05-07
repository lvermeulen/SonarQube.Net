using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
    public partial class SonarQubeClientShould
    {
        [Fact]
        public async Task ValidateCredentialsAsync()
        {
            bool result = await _client.ValidateCredentialsAsync().ConfigureAwait(false);
            Assert.True(result);
        }
    }
}
