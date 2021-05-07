using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class BadgeMetricTypesConverter : StringConverter<BadgeMetricTypes>
	{
		public static BadgeMetricTypesConverter Instance { get; } = new BadgeMetricTypesConverter();

		public static string ToString(BadgeMetricTypes value) => Instance.ConvertToString(value);

		public override Dictionary<BadgeMetricTypes, string> Map { get; } = new Dictionary<BadgeMetricTypes, string>
		{
			[BadgeMetricTypes.Bugs] = "bugs",
			[BadgeMetricTypes.CodeSmells] = "code_smells",
			[BadgeMetricTypes.Coverage] = "coverage",
			[BadgeMetricTypes.DuplicatedLinesDensity] = "duplicated_lines_density",
			[BadgeMetricTypes.Ncloc] = "ncloc",
			[BadgeMetricTypes.SqaleRating] = "sqale_rating",
			[BadgeMetricTypes.AlertStatus] = "alert_status",
			[BadgeMetricTypes.ReliabilityRating] = "reliability_rating",
			[BadgeMetricTypes.SecurityRating] = "security_rating",
			[BadgeMetricTypes.SqaleIndex] = "sqale_index",
			[BadgeMetricTypes.Vulnerabilities] = "vulnerabilities"
		};

		public override string Description => "badge metric type";
	}
}
