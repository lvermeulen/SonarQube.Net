using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class MeasureSearchStrategiesConverter : JsonEnumConverter<MeasureSearchStrategies>
	{
		public static MeasureSearchStrategiesConverter Instance { get; } = new MeasureSearchStrategiesConverter();

		public static string ToString(MeasureSearchStrategies value) => Instance.ConvertToString(value);

		public static string ToString(MeasureSearchStrategies? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<MeasureSearchStrategies, string> Map { get; } = new Dictionary<MeasureSearchStrategies, string>
		{
			[MeasureSearchStrategies.All] = "all",
			[MeasureSearchStrategies.Children] = "children",
			[MeasureSearchStrategies.Leaves] = "leaves"
		};

		public override string Description { get; } = "measure search strategy";
	}
}
