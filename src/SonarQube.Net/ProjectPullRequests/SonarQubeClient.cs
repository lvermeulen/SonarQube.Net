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
		private IFlurlRequest GetProjectPullRequestsUrl() => GetBaseUrl("/api/project_pull_requests");

		private IFlurlRequest GetProjectPullRequestsUrl(string path) => GetProjectPullRequestsUrl().AppendPathSegment(path);

		public async Task<bool> DeleteProjectPullRequestAsync(string project, string pullRequest)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(pullRequest)] = pullRequest
			};

			var response = await GetProjectPullRequestsUrl("delete")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<ProjectPullRequest>> GetProjectPullRequestsListAsync(string project)
		{
			return await GetProjectPullRequestsUrl("list")
				.SetQueryParam(nameof(project), project)
				.GetJsonFirstNodeAsync<IEnumerable<ProjectPullRequest>>()
				.ConfigureAwait(false);
		}
	}
}
