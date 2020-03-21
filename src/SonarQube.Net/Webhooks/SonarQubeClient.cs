using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetWebhooksUrl() => GetBaseUrl("/api/webhooks");

		private IFlurlRequest GetWebhooksUrl(string path) => GetWebhooksUrl().AppendPathSegment(path);

		public async Task<Webhook> CreateWebhookAsync(string name, string url, string project = null, string secret = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(url)] = url,
				[nameof(project)] = project,
				[nameof(secret)] = secret
			};

			var response = await GetPluginsUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Webhook>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteWebhookAsync(string webhook)
		{
			var response = await GetPluginsUrl("delete")
				.SetQueryParams(nameof(webhook), webhook)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<WebhookDelivery>> GetWebhookDeliveriesAsync(string ceTaskId = null, string componentKey = null, int? p = null, int? ps = null, string webhook = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(ceTaskId)] = ceTaskId,
				[nameof(componentKey)] = componentKey,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(webhook)] = webhook
			};

			return await GetWebhooksUrl("deliveries")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<WebhookDelivery>>("deliveries")
				.ConfigureAwait(false);
		}

		public async Task<WebhookDelivery> GetWebhookDeliveryAsync(string deliveryId)
		{
			return await GetWebhooksUrl("delivery")
				.SetQueryParam(nameof(deliveryId), deliveryId)
				.GetJsonFirstNodeAsync<WebhookDelivery>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Webhook>> GetWebhooksListAsync(string project = null)
		{
			return await GetWebhooksUrl("list")
				.SetQueryParam(nameof(project), project)
				.GetJsonFirstNodeAsync<IEnumerable<Webhook>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateWebhookAsync(string name, string url, string webhook, string secret = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(url)] = url,
				[nameof(webhook)] = webhook,
				[nameof(secret)] = secret
			};

			var response = await GetPluginsUrl("update")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
