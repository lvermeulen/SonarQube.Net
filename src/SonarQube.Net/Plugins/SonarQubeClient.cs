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
		private IFlurlRequest GetPluginsUrl() => GetBaseUrl("/api/plugins");

		private IFlurlRequest GetPluginsUrl(string path) => GetPluginsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<AvailablePlugin>> GetAvailablePluginsAsync()
		{
			return await GetPluginsUrl("available")
				.GetJsonFirstNodeAsync<IEnumerable<AvailablePlugin>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> CancelAllPluginsAsync()
		{
			var response = await GetPluginsUrl("cancel_all")
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> InstallPluginAsync(string key)
		{
			var response = await GetPluginsUrl("install")
				.SetQueryParam(nameof(key), key)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<InstalledPlugin>> GetInstalledPluginsAsync(string f = null)
		{
			return await GetPluginsUrl("installed")
				.SetQueryParam(nameof(f), f)
				.GetJsonFirstNodeAsync<IEnumerable<InstalledPlugin>>()
				.ConfigureAwait(false);
		}

		public async Task<PendingPlugins> GetPendingPluginsAsync()
		{
			return await GetPluginsUrl("pending")
				.GetJsonAsync<PendingPlugins>()
				.ConfigureAwait(false);
		}

		public async Task<bool> UninstallPluginAsync(string key)
		{
			var response = await GetPluginsUrl("uninstall")
				.SetQueryParam(nameof(key), key)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdatePluginAsync(string key)
		{
			var response = await GetPluginsUrl("update")
				.SetQueryParam(nameof(key), key)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<UpdatedPlugin>> GetUpdatedPluginsAsync()
		{
			return await GetPluginsUrl("updates")
				.GetJsonFirstNodeAsync<IEnumerable<UpdatedPlugin>>()
				.ConfigureAwait(false);
		}
	}
}
