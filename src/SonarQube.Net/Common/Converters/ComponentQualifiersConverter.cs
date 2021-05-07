using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class ComponentQualifiersConverter : JsonEnumConverter<ComponentQualifiers>
	{
		public static ComponentQualifiersConverter Instance { get; } = new ComponentQualifiersConverter();

		public static string ToString(ComponentQualifiers value) => Instance.ConvertToString(value);

		public static string ToString(ComponentQualifiers? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<ComponentQualifiers, string> Map { get; } = new Dictionary<ComponentQualifiers, string>
		{
			[ComponentQualifiers.Brc] = "BRC",
			[ComponentQualifiers.Dir] = "DIR",
			[ComponentQualifiers.Fil] = "FIL",
			[ComponentQualifiers.Trk] = "TRK",
			[ComponentQualifiers.Uts] = "UTS"
		};

		public override string Description => "component qualifier";
	}
}
