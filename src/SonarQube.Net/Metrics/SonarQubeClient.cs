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
		private IFlurlRequest GetMetricsUrl() => GetBaseUrl("/api/metrics");

		private IFlurlRequest GetMetricsUrl(string path) => GetMetricsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<Metric>> SearchMetricsAsync(int? ps = null, int? p = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(ps)] = ps,
				[nameof(p)] = p
			};

			return await GetMetricsUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<Metric>>()
				.ConfigureAwait(false);
		}

		public async Task<MetricTypes> GetMetricTypesAsync()
		{
			return await GetMetricsUrl("types")
				.GetJsonAsync<MetricTypes>()
				.ConfigureAwait(false);
		}
	}
}
