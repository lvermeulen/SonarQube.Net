using System;
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
		private IFlurlRequest GetProjectAnalysesUrl() => GetBaseUrl("/api/project_analyses");

		private IFlurlRequest GetProjectAnalysesUrl(string path) => GetProjectAnalysesUrl().AppendPathSegment(path);

		public async Task<ProjectAnalysisEvent> CreateProjectAnalysisEventAsync(string analysis, EventCategories? category = null, string name = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(analysis)] = analysis,
				[nameof(category)] = EventCategoriesConverter.ToString(category),
				[nameof(name)] = name 
			};

			var response = await GetProjectAnalysesUrl("create_event")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<ProjectAnalysisEvent>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteProjectAnalysisAsync(string analysis)
		{
			var response = await GetProjectAnalysesUrl("delete")
				.SetQueryParam(nameof(analysis), analysis)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteProjectAnalysisEventAsync(string evt)
		{
			var response = await GetProjectAnalysesUrl("delete_event")
				.SetQueryParam("event", evt)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<ProjectAnalysis>> SearchProjectAnalysesAsync(string project, EventCategories? category = null, int? p = null, int? ps = null, DateTime? from = null, DateTime? to = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(category)] = EventCategoriesConverter.ToString(category),
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(from)] = DateTimeToStringConverter.ToString(from),
				[nameof(to)] = DateTimeToStringConverter.ToString(to)
			};

			return await GetProjectAnalysesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<ProjectAnalysis>>("analyses")
				.ConfigureAwait(false);
		}

		public async Task<ProjectAnalysisEvent> UpdateProjectAnalysisEventAsync(string evt, string name)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["event"] = evt,
				[nameof(name)] = name
			};

			var response = await GetProjectAnalysesUrl("update_event")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<ProjectAnalysisEvent>(response).ConfigureAwait(false);
		}
	}
}
