using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SystemProcessTypesToStringConverter : StringConverter<SystemProcessTypes>
	{
		public static SystemProcessTypesToStringConverter Instance { get; } = new SystemProcessTypesToStringConverter();

		public static string ToString(SystemProcessTypes value) => Instance.ConvertToString(value);

		public static string ToString(SystemProcessTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<SystemProcessTypes, string> Map { get; } = new Dictionary<SystemProcessTypes, string>
		{
			[SystemProcessTypes.App] = "app",
			[SystemProcessTypes.Ce] = "ce",
			[SystemProcessTypes.Es] = "es",
			[SystemProcessTypes.Web] = "web"
		};

		public override string Description => "system process";
	}
}
