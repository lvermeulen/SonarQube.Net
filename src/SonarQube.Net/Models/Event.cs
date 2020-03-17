using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class Event : KeyedName
	{
		[JsonConverter(typeof(EventCategoriesConverter))]
		public EventCategories Category { get; set; }

		public string Description { get; set; }
		public QualityGate QualityGate { get; set; }
	}
}