using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class IssueRule : KeyedName
	{
		[JsonConverter(typeof(RuleStatusesConverter))]
		public RuleStatuses Status { get; set; }

		public string Lang { get; set; }
		public string LangName { get; set; }
	}
}