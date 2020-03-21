using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class SearchQualityProfiles
	{
		public IEnumerable<FullQualityProfile> Profiles { get; set; }
		public IDictionary<string, bool?> Actions { get; set; }
	}
}
