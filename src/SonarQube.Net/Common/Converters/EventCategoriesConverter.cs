using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class EventCategoriesConverter : JsonEnumConverter<EventCategories>
	{
		public static EventCategoriesConverter Instance { get; } = new EventCategoriesConverter();

		public static string ToString(EventCategories value) => Instance.ConvertToString(value);

		public static string ToString(EventCategories? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<EventCategories, string> Map { get; } = new Dictionary<EventCategories, string>
		{
			[EventCategories.Version] = "VERSION",
			[EventCategories.Other] = "OTHER",
			[EventCategories.QualityProfile] = "QUALITY_PROFILE",
			[EventCategories.QualityGate] = "QUALITY_GATE",
			[EventCategories.DefinitionChange] = "DEFINITION_CHANGE"
		};

		public override string Description => "event category";
	}
}
