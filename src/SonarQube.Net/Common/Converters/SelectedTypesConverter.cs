using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SelectedTypesConverter : StringConverter<SelectedTypes>
	{
		public static SelectedTypesConverter Instance { get; } = new SelectedTypesConverter();

		public static string ToString(SelectedTypes value) => Instance.ConvertToString(value);

		public static string ToString(SelectedTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<SelectedTypes, string> Map { get; } = new Dictionary<SelectedTypes, string>
		{
			[SelectedTypes.All] = "all",
			[SelectedTypes.Deselected] = "deselected",
			[SelectedTypes.Selected] = "selected"
		};

		public override string Description => "selection type";
	}
}
