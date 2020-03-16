using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Common.Converters;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetSourcesUrl() => GetBaseUrl("/api/sources");

		private IFlurlRequest GetSourcesUrl(string path) => GetSourcesUrl().AppendPathSegment(path);

		public async Task<string> GetRawSourcesAsync(string key)
		{
			return await GetSourcesUrl("raw")
				.SetQueryParam(nameof(key), key)
				.GetStringAsync()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Tuple<int, string, string, string>>> GetScmSourcesAsync(string key, bool? commitsByLine = null, string from = null, string to = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				["commits_by_line"] = commitsByLine,
				[nameof(from)] = from,
				[nameof(to)] = to
			};

			return await GetSourcesUrl("scm")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<Tuple<int, string, string, string>>, TupleFourTypesConverter<int, string, string, string>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Tuple<int, string>>> ShowSourceAsync(string key, string from = null, string to = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(from)] = from,
				[nameof(to)] = to
			};

			return await GetSourcesUrl("show")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<Tuple<int, string>>, TupleTwoTypesConverter<int, string>>()
				.ConfigureAwait(false);
		}
	}
}
