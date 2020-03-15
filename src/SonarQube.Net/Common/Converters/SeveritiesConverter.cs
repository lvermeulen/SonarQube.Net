using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SeveritiesConverter : JsonEnumConverter<Severities>
	{
		public static SeveritiesConverter Instance { get; } = new SeveritiesConverter();

		public static string ToString(Severities value) => Instance.ConvertToString(value);

		public static string ToString(Severities? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<Severities, string> Map { get; } = new Dictionary<Severities, string>
		{
			[Severities.Info] = "INFO",
			[Severities.Minor] = "MINOR",
			[Severities.Major] = "MAJOR",
			[Severities.Critical] = "CRITICAL",
			[Severities.Blocker] = "BLOCKER"
		};

		public override string Description { get; } = "issue severity";
	}
}
