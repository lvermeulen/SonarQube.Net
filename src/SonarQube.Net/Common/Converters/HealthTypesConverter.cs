using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class HealthTypesConverter : JsonEnumConverter<HealthTypes>
	{
		public override Dictionary<HealthTypes, string> Map { get; } = new Dictionary<HealthTypes, string>
		{
			[HealthTypes.Green] = "GREEN",
			[HealthTypes.Yellow] = "YELLOW",
			[HealthTypes.Red] = "RED"
		};

		public override string Description => "health type";
	}
}
