using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class ComponentTreeStrategiesToStringConverter : StringConverter<ComponentTreeStrategies>
	{
		public static ComponentTreeStrategiesToStringConverter Instance { get; } = new ComponentTreeStrategiesToStringConverter();

		public static string ToString(ComponentTreeStrategies value) => Instance.ConvertToString(value);

		public static string ToString(ComponentTreeStrategies? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<ComponentTreeStrategies, string> Map { get; } = new Dictionary<ComponentTreeStrategies, string>
		{
			[ComponentTreeStrategies.All] = "all",
			[ComponentTreeStrategies.Children] = "children",
			[ComponentTreeStrategies.Leaves] = "leaves"
		};

		public override string Description { get; } = "component tree strategy";
	}
}
