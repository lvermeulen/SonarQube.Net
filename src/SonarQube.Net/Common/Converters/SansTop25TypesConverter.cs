using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SansTop25TypesConverter : JsonEnumConverter<SansTop25Types>
	{
		public static SansTop25TypesConverter Instance { get; } = new SansTop25TypesConverter();

		public static string ToString(SansTop25Types value) => Instance.ConvertToString(value);

		public override Dictionary<SansTop25Types, string> Map { get; } = new Dictionary<SansTop25Types, string>
		{
			[SansTop25Types.InsecureInteraction] = "insecure-interaction",
			[SansTop25Types.RiskyResource] = "risky-resource",
			[SansTop25Types.PorousDefenses] = "porous-defenses"
		};

		public override string Description => "sans top 25 type";
	}
}
