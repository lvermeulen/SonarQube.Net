using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SelectedQualityGateTypesConverter : StringConverter<SelectedQualityGateTypes>
	{
		public static SelectedQualityGateTypesConverter Instance { get; } = new SelectedQualityGateTypesConverter();

		public static string ToString(SelectedQualityGateTypes value) => Instance.ConvertToString(value);

		public static string ToString(SelectedQualityGateTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<SelectedQualityGateTypes, string> Map { get; } = new Dictionary<SelectedQualityGateTypes, string>
		{
			[SelectedQualityGateTypes.All] = "all",
			[SelectedQualityGateTypes.Deselected] = "deselected",
			[SelectedQualityGateTypes.Selected] = "selected"
		};

		public override string Description { get; } = "selected quality gate";
	}
}
