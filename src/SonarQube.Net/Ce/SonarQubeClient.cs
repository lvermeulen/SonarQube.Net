using System;
using System.Collections.Generic;
using System.Linq;
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
		private IFlurlRequest GetCeUrl() => GetBaseUrl("/api/ce");

		private IFlurlRequest GetCeUrl(string path) => GetCeUrl().AppendPathSegment(path);

		public async Task<IEnumerable<CeTask>> GetCeActivityAsync(string component = null, DateTime? maxExecutedAt = null, DateTime? minSubmittedAt = null, bool? onlyCurrents = null,
			int? ps = null, string q = null, CeTaskStatuses[] status = null, string type = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(maxExecutedAt)] = DateTimeToStringConverter.ToString(maxExecutedAt),
				[nameof(minSubmittedAt)] = DateTimeToStringConverter.ToString(minSubmittedAt),
				[nameof(onlyCurrents)] = BooleanConverter.ToString(onlyCurrents),
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(status)] = status == null ? null : string.Join(",", status.Select(CeTaskStatusesConverter.ToString)),
				[nameof(type)] = type,
			};

			return await GetCeUrl("activity")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<CeTask>>()
				.ConfigureAwait(false);
		}

		public async Task<CeActivityStatus> GetCeActivityStatusAsync(string componentId)
		{
			return await GetCeUrl("activity_status")
				.SetQueryParam(componentId)
				.GetJsonAsync<CeActivityStatus>()
				.ConfigureAwait(false);
		}

		public async Task<CeComponent> GetCeComponentAsync(string component = null, string componentId = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(componentId)] = componentId
			};

			return await GetCeUrl("component")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<CeComponent>()
				.ConfigureAwait(false);
		}

		public async Task<CeTask> GetCeTaskAsync(string id, params string[] additionalFields)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(additionalFields)] = additionalFields == null ? null : string.Join(",", additionalFields)
			};

			return await GetCeUrl("task")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<CeTask>()
				.ConfigureAwait(false);
		}
	}
}
