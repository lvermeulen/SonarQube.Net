using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class ComponentAncestor : FullComponentBase
	{
		public string Description { get; set; }
		public IEnumerable<string> Tags { get; set; }

		[JsonConverter(typeof(ProjectVisibilitiesConverter))]
		public ProjectVisibilities Visibility { get; set; }
	}
}