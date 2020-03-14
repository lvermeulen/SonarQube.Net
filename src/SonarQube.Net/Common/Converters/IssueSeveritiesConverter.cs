using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueSeveritiesConverter : JsonEnumConverter<IssueSeverities>
	{
		public static IssueSeveritiesConverter Instance { get; } = new IssueSeveritiesConverter();

		public static string ToString(IssueSeverities value) => Instance.ConvertToString(value);

		public override Dictionary<IssueSeverities, string> Map { get; } = new Dictionary<IssueSeverities, string>
		{
			[IssueSeverities.Info] = "INFO",
			[IssueSeverities.Minor] = "MINOR",
			[IssueSeverities.Major] = "MAJOR",
			[IssueSeverities.Critical] = "CRITICAL",
			[IssueSeverities.Blocker] = "BLOCKER"
		};

		public override string Description { get; } = "issue severity";
	}
}
