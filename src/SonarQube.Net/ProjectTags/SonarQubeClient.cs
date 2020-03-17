using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetProjectTagsUrl() => GetBaseUrl("/api/project_tags");

		private IFlurlRequest GetProjectTagsUrl(string path) => GetProjectTagsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<string>> SearchProjectTagsAsync(int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetProjectTagsUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<string>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> SetProjectTagsAsync(string project, string[] tags)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(tags)] = string.Join(",", tags)
			};

			var response = await GetProjectTagsUrl("set")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
