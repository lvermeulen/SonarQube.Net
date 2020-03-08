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
		private IFlurlRequest GetNewCodePeriodsUrl() => GetBaseUrl("/api/new_code_periods");

		private IFlurlRequest GetNewCodePeriodsUrl(string path) => GetNewCodePeriodsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<NewCodePeriod>> GetNewCodePeriodsListAsync(string project)
		{
			return await GetNewCodePeriodsUrl("list")
				.SetQueryParam(nameof(project), project)
				.GetJsonFirstNodeAsync<IEnumerable<NewCodePeriod>>()
				.ConfigureAwait(false);
		}

		public async Task<bool> SetNewCodePeriodAsync(string type, string branch = null, string project = null, string value = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(type)] = type,
				[nameof(branch)] = branch,
				[nameof(project)] = project,
				[nameof(value)] = value
			};

			var response = await GetNewCodePeriodsUrl("set")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<NewCodePeriod> ShowNewCodePeriodAsync(string branch = null, string project = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(branch)] = branch,
				[nameof(project)] = project
			};

			return await GetNewCodePeriodsUrl("show")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<NewCodePeriod>()
				.ConfigureAwait(false);
		}

		public async Task<bool> UnsetNewCodePeriodAsync(string branch = null, string project = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(branch)] = branch,
				[nameof(project)] = project
			};

			var response = await GetNewCodePeriodsUrl("unset")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
