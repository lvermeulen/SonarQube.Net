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
		private IFlurlRequest GetProjectBranchesUrl() => GetBaseUrl("/api/project_branches");

		private IFlurlRequest GetProjectBranchesUrl(string path) => GetProjectBranchesUrl().AppendPathSegment(path);

		public async Task<bool> DeleteProjectBranchAsync(string project, string branch)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(branch)] = branch
			};

			var response = await GetProjectBranchesUrl("delete")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<ProjectBranch>> GetProjectBranchesListAsync(string project)
		{
			return await GetProjectBranchesUrl("list")
				.SetQueryParam(nameof(project), project)
				.GetJsonFirstNodeAsync<IEnumerable<ProjectBranch>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> RenameMainProjectBranchAsync(string project, string name)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(name)] = name
			};

			var response = await GetProjectBranchesUrl("rename")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> SetProjectBranchAutomaticDeletionProtectionAsync(string project, string branch, bool value)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(branch)] = branch,
				[nameof(value)] = value
			};

			var response = await GetProjectBranchesUrl("set_automatic_deletion_protection")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
