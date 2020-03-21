using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetQualityGatesUrl() => GetBaseUrl("/api/qualitygates");

		private IFlurlRequest GetQualityGatesUrl(string path) => GetQualityGatesUrl().AppendPathSegment(path);

		public async Task<bool> CopyQualityGateAsync(int id, string name, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(name)] = name,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("copy")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<QualityGateIdName> CreateQualityGateAsync(string name, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<QualityGateIdName>(response).ConfigureAwait(false);
		}

		public async Task<QualityGateConditionRef> CreateQualityGateConditionAsync(int error, int gateId, string metric, QualityGateConditionOperatorTypes? op = null, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(error)] = error,
				[nameof(gateId)] = gateId,
				[nameof(metric)] = metric,
				[nameof(op)] = QualityGateConditionOperatorTypesConverter.ToString(op),
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("create_condition")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<QualityGateConditionRef>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteQualityGateConditionAsync(int id, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("delete_condition")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeselectQualityGateAsync(string organization = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(organization)] = organization,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetQualityGatesUrl("deselect")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DestroyQualityGateAsync(int id, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("destroy")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<QualityGateIdName> GetProjectQualityGateAsync(string project, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(organization)] = organization
			};

			return await GetQualityGatesUrl("get_by_project")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<QualityGateIdName>()
				.ConfigureAwait(false);
		}

		public async Task<QualityGatesList> GetQualityGatesListAsync(string organization = null)
		{
			return await GetQualityGatesUrl("list")
				.SetQueryParam(nameof(organization), organization)
				.GetJsonAsync<QualityGatesList>()
				.ConfigureAwait(false);
		}

		public async Task<QualityGatesProjectStatus> GetQualityGatesProjectStatusAsync(string projectId = null, string projectKey = null, string analysisId = null, string branch = null, string pullRequest = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey,
				[nameof(analysisId)] = analysisId,
				[nameof(branch)] = branch,
				[nameof(pullRequest)] = pullRequest
			};

			return await GetQualityGatesUrl("project_status")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<QualityGatesProjectStatus>()
				.ConfigureAwait(false);
		}

		public async Task<bool> RenameQualityGateAsync(int id, string name, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(name)] = name,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("rename")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SelectedQualityGate>> SearchQualityGatesAsync(int gateId, string organization = null, int? page = null, int? pageSize = null, string query = null, SelectedTypes? selected = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(gateId)] = gateId,
				[nameof(organization)] = organization,
				[nameof(page)] = page,
				[nameof(pageSize)] = pageSize,
				[nameof(query)] = query,
				[nameof(selected)] = SelectedTypesConverter.ToString(selected)
			};

			return await GetQualityGatesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync< IEnumerable<SelectedQualityGate>>("results")
				.ConfigureAwait(false);
		}

		public async Task<bool> SelectQualityGateAsync(int gateId, string organization = null, string projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(gateId)] = gateId,
				[nameof(organization)] = organization,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetQualityGatesUrl("select")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> SetDefaultQualityGateAsync(int id, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("set_as_default")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<QualityGateRef> ShowQualityGateAsync(int? id = null, string name = null, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(name)] = name,
				[nameof(organization)] = organization
			};

			return await GetQualityGatesUrl("show")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<QualityGateRef>()
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateQualityGateConditionAsync(int error, int id, string metric, QualityGateConditionOperatorTypes? op = null, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(error)] = error,
				[nameof(id)] = id,
				[nameof(metric)] = metric,
				[nameof(op)] = QualityGateConditionOperatorTypesConverter.ToString(op),
				[nameof(organization)] = organization
			};

			var response = await GetQualityGatesUrl("update_condition")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
