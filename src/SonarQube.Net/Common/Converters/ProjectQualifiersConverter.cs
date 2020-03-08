using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class ProjectQualifiersConverter : JsonEnumConverter<ProjectQualifiers>
	{
		public static ProjectQualifiersConverter Instance { get; } = new ProjectQualifiersConverter();

		public static string ToString(ProjectQualifiers value) => Instance.ConvertToString(value);

		public override Dictionary<ProjectQualifiers, string> Map { get; } = new Dictionary<ProjectQualifiers, string>
		{
			[ProjectQualifiers.Trk] = "TRK",
			[ProjectQualifiers.Vw] = "VW",
			[ProjectQualifiers.App] = "APP"
		};

		public override string Description { get; } = "project qualifier";
	}
}
