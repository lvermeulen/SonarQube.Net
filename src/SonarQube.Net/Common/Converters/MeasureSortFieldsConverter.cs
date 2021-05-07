using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class MeasureSortFieldsConverter : JsonEnumConverter<MeasureSortFields>
	{
		public static MeasureSortFieldsConverter Instance { get; } = new MeasureSortFieldsConverter();

		public static string ToString(MeasureSortFields value) => Instance.ConvertToString(value);

		public override Dictionary<MeasureSortFields, string> Map { get; } = new Dictionary<MeasureSortFields, string>
		{
			[MeasureSortFields.Metric] = "metric",
			[MeasureSortFields.MetricPeriod] = "metricPeriod",
			[MeasureSortFields.Name] = "name",
			[MeasureSortFields.Path] = "path",
			[MeasureSortFields.Qualifier] = "qualifier"
		};

		public override string Description => "measure sort field";
	}
}
