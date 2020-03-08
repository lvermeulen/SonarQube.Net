using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class NewCodePeriod
	{
		public string ProjectKey { get; set; }
		public string BranchKey { get; set; }

		[JsonConverter(typeof(NewCodePeriodTypeConverter))]
		public NewCodePeriodTypes Type { get; set; }

		public string Value { get; set; }
		public string EffectiveValue { get; set; }
		public bool? Inherited { get; set; }
	}
}
