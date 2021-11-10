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
		private IFlurlRequest GetSettingsUrl() => GetBaseUrl("/api/settings");

		private IFlurlRequest GetSettingsUrl(string path) => GetSettingsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<SettingsDefinition>> GetSettingsDefinitionsListAsync(string component = null)
		{
			return await GetSettingsUrl("list_definitions")
				.SetQueryParam(nameof(component), component)
				.GetJsonFirstNodeAsync<IEnumerable<SettingsDefinition>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> ResetSettingsAsync(string[] keys, string component)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(keys)] = keys == null ? null : string.Join(",", keys)
			};

			var response = await GetSettingsUrl("reset")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> SetSettingAsync(string key, string component = null, string[] fieldValues = null, string value = null, string[] values = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(component)] = component,
				[nameof(fieldValues)] = fieldValues,
				[nameof(value)] = value,
				[nameof(values)] = values
			};

			//sending data as application/x-www-form-urlencoded in order to support large values arrays
			var response = await GetSettingsUrl("set")
				.PostUrlEncodedAsync(queryParamValues)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SettingsValue>> GetSettingsValuesAsync(string component = null, string[] keys = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(keys)] = keys == null ? null : string.Join(",", keys)
			};

			return await GetSettingsUrl("values")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<SettingsValue>>()
				.ConfigureAwait(false);
		}
	}
}
