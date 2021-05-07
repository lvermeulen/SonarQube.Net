using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class OwaspTop10TypesConverter : JsonEnumConverter<OwaspTop10Types>
	{
		public static OwaspTop10TypesConverter Instance { get; } = new OwaspTop10TypesConverter();

		public static string ToString(OwaspTop10Types value) => Instance.ConvertToString(value);

		public override Dictionary<OwaspTop10Types, string> Map { get; } = new Dictionary<OwaspTop10Types, string>
		{
			[OwaspTop10Types.A1] = "a1",
			[OwaspTop10Types.A2] = "a2",
			[OwaspTop10Types.A3] = "a3",
			[OwaspTop10Types.A4] = "a4",
			[OwaspTop10Types.A5] = "a5",
			[OwaspTop10Types.A6] = "a6",
			[OwaspTop10Types.A7] = "a7",
			[OwaspTop10Types.A8] = "a8",
			[OwaspTop10Types.A9] = "a9",
			[OwaspTop10Types.A10] = "a10"
		};

		public override string Description => "owasp top 10 type";
	}
}
