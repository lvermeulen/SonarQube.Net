using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		[Fact]
		public async Task GetWebhookDeliveriesAsync()
		{
			var results = await _client.GetWebhooksListAsync().ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWebhookDeliveriesAsync(webhook: firstResult.Key).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetWebhookDeliveryAsync()
		{
			var webhooks = await _client.GetWebhooksListAsync().ConfigureAwait(false);
			var firstWebhook = webhooks.FirstOrDefault();
			if (firstWebhook == null)
			{
				return;
			}

			var results = await _client.GetWebhookDeliveriesAsync(webhook: firstWebhook.Key).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetWebhookDeliveryAsync(firstResult.Id).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Fact]
		public async Task GetWebhooksListAsync()
		{
			var result = await _client.GetWebhooksListAsync().ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
