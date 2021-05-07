using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class QualityProfileExporterKeysConverter : StringConverter<QualityProfileExporterKeys>
	{
		public static QualityProfileExporterKeysConverter Instance { get; } = new QualityProfileExporterKeysConverter();

		public static string ToString(QualityProfileExporterKeys value) => Instance.ConvertToString(value);

		public static string ToString(QualityProfileExporterKeys? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<QualityProfileExporterKeys, string> Map { get; } = new Dictionary<QualityProfileExporterKeys, string>
		{
			[QualityProfileExporterKeys.SonarlintVsVbnet] = "sonarlint-vs-vbnet",
			[QualityProfileExporterKeys.SonarlintVsCs] = "sonarlint-vs-cs",
			[QualityProfileExporterKeys.RoslynVbnet] = "roslyn-vbnet",
			[QualityProfileExporterKeys.RoslynCs] = "roslyn - cs"
		};

		public override string Description => "quality profile exporter key";
	}
}
