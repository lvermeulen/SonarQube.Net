using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class ProjectVisibilitiesConverter : JsonEnumConverter<ProjectVisibilities>
	{
		public static ProjectVisibilitiesConverter Instance { get; } = new ProjectVisibilitiesConverter();

		public static string ToString(ProjectVisibilities value) => Instance.ConvertToString(value);

		public static string ToString(ProjectVisibilities? value) => value.HasValue ? Instance.ConvertToString(value.Value) : null;

		public override Dictionary<ProjectVisibilities, string> Map { get; } = new Dictionary<ProjectVisibilities, string>
		{
			[ProjectVisibilities.Private] = "private",
			[ProjectVisibilities.Public] = "public"
		};

		public override string Description => "project visibility";
	}
}
