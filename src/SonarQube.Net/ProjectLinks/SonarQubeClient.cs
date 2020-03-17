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
		private IFlurlRequest GetProjectLinksUrl() => GetBaseUrl("/api/project_links");

		private IFlurlRequest GetProjectLinksUrl(string path) => GetProjectLinksUrl().AppendPathSegment(path);

		public async Task<ProjectLink> CreateProjectLinkAsync(string name, string url, int? projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(url)] = url,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetProjectLinksUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<ProjectLink>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteProjectLinkAsync(string id)
		{
			var response = await GetProjectLinksUrl("delete")
				.SetQueryParam(nameof(id), id)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<ProjectLink>> SearchProjectLinksAsync(int? projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			return await GetProjectLinksUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<ProjectLink>>()
				.ConfigureAwait(false);
		}
	}
}
