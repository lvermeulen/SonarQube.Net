using System;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class ProjectComponent : KeyedName
	{
		public string Organization { get; set; }

		[JsonConverter(typeof(ProjectQualifiersConverter))]
		public ProjectQualifiers Qualifier { get; set; }

		[JsonConverter(typeof(ProjectVisibilitiesConverter))]
		public ProjectVisibilities Visibility { get; set; }

		public DateTime? LastAnalysisDate { get; set; }
		public string Revision { get; set; }
	}
}
