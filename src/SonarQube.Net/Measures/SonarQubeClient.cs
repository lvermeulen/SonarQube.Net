using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetMeasuresUrl() => GetBaseUrl("/api/measures");

		private IFlurlRequest GetMeasuresUrl(string path) => GetMeasuresUrl().AppendPathSegment(path);

		public async Task<ComponentMeasure> GetMeasuresComponentAsync(string component, string[] metricKeys, AvailableMeasureFields[] additionalFields = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(metricKeys)] = string.Join(",", metricKeys),
				[nameof(additionalFields)] = additionalFields == null ? null : string.Join(",", additionalFields.Select(AvailableMeasureFieldsConverter.ToString))
			};

			return await GetMeasuresUrl("component")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<ComponentMeasure>()
				.ConfigureAwait(false);
		}

		public async Task<ComponentTreeMeasure> GetMeasuresComponentTreeAsync(string component, string[] metricKeys, AvailableMeasureFields[] additionalFields = null, bool? asc = null,
			int? metricPeriodSort = null, string metricSort = null, MetricSortFilters? metricSortFilter = null, int? p = null, int? ps = null, string q = null,
			ComponentQualifiers[] qualifiers = null, MeasureSortFields[] s = null, MeasureSearchStrategies? strategy = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(metricKeys)] = string.Join(",", metricKeys),
				[nameof(additionalFields)] = additionalFields == null ? null : string.Join(",", additionalFields.Select(AvailableMeasureFieldsConverter.ToString)),
				[nameof(asc)] = BooleanConverter.ToString(asc),
				[nameof(metricPeriodSort)] = metricPeriodSort,
				[nameof(metricSort)] = metricSort,
				[nameof(metricSortFilter)] = metricSortFilter == null ? null : MetricSortFiltersConverter.ToString(metricSortFilter),
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ComponentQualifiersConverter.ToString)),
				[nameof(s)] = s == null ? null : string.Join(",", s.Select(MeasureSortFieldsConverter.ToString)),
				[nameof(strategy)] = strategy == null ? null : MeasureSearchStrategiesConverter.ToString(strategy)
			};

			return await GetMeasuresUrl("component_tree")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<ComponentTreeMeasure>()
				.ConfigureAwait(false);
		}

		public async Task<MeasuresHistory> SearchMeasuresHistoryAsync(string component, string[] metrics, DateTime? from = null, DateTime? to = null, int? p = null, int? ps = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(metrics)] = string.Join(",", metrics),
				[nameof(from)] = DateTimeToStringConverter.ToString(from),
				[nameof(to)] = DateTimeToStringConverter.ToString(to),
				[nameof(p)] = p,
				[nameof(ps)] = ps
			};

			return await GetMeasuresUrl("search_history")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<MeasuresHistory>()
				.ConfigureAwait(false);
		}
	}
}
