using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class MetricSortFiltersConverter : JsonEnumConverter<MetricSortFilters>
	{
		public static MetricSortFiltersConverter Instance { get; } = new MetricSortFiltersConverter();

		public static string ToString(MetricSortFilters value) => Instance.ConvertToString(value);

		public static string ToString(MetricSortFilters? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<MetricSortFilters, string> Map { get; } = new Dictionary<MetricSortFilters, string>
		{
			[MetricSortFilters.All] = "all",
			[MetricSortFilters.WithMeasuresOnly] = "withMeasuresOnly"
		};

		public override string Description => "metric sort filter";
	}
}
