using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class MeasureComponent : KeyedName
	{
		[JsonConverter(typeof(ComponentQualifiersConverter))]
		public ComponentQualifiers Qualifier { get; set; }

		public string Language { get; set; }
		public string Path { get; set; }
		public IEnumerable<Measure> Measures { get; set; }
	}
}