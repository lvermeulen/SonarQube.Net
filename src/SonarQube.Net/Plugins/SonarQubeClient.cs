using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetPluginsUrl() => GetBaseUrl("/api/plugins");

		public async Task<IEnumerable<AvailablePlugin>> GetAvailablePluginsAsync()
		{
			return await GetPluginsUrl()
				.AppendPathSegment("/available")
				.GetJsonFirstNodeAsync<IEnumerable<AvailablePlugin>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> CancelAllPluginsAsync()
		{
			var response = await GetPluginsUrl()
				.AppendPathSegment("/cancel_all")
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> InstallPluginAsync(string key)
		{
			var response = await GetPluginsUrl()
				.AppendPathSegment("/install")
				.SetQueryParam(nameof(key), key)
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<InstalledPlugin>> GetInstalledPluginsAsync(string f = null)
		{
			return await GetPluginsUrl()
				.AppendPathSegment("/installed")
				.SetQueryParam(nameof(f), f)
				.GetJsonFirstNodeAsync<IEnumerable<InstalledPlugin>>()
				.ConfigureAwait(false);
		}

		public async Task<PendingPlugins> GetPendingPluginsAsync()
		{
			return await GetPluginsUrl()
				.AppendPathSegment("/pending")
				.GetJsonAsync<PendingPlugins>()
				.ConfigureAwait(false);
		}

		public async Task<bool> UninstallPluginAsync(string key)
		{
			var response = await GetPluginsUrl()
				.AppendPathSegment("/uninstall")
				.SetQueryParam(nameof(key), key)
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdatePluginAsync(string key)
		{
			var response = await GetPluginsUrl()
				.AppendPathSegment("/update")
				.SetQueryParam(nameof(key), key)
				.PostAsync(new StringContent(""))
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<UpdatedPlugin>> GetUpdatedPluginsAsync()
		{
			return await GetPluginsUrl()
				.AppendPathSegment("/updates")
				.GetJsonFirstNodeAsync<IEnumerable<UpdatedPlugin>>()
				.ConfigureAwait(false);
		}
	}
}
