using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class QualityGateConditionRef
	{
		public string Id { get; set; }
		public string Metric { get; set; }

		[JsonConverter(typeof(QualityGateConditionOperatorTypesConverter))]
		public QualityGateConditionOperatorTypes Op { get; set; }

		public string Error { get; set; }
		public string Warning { get; set; }
	}
}
