using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class LogLevelsConverter : JsonEnumConverter<LogLevels>
	{
		public static LogLevelsConverter Instance { get; } = new LogLevelsConverter();

		public static string ToString(LogLevels value) => Instance.ConvertToString(value);

		public override Dictionary<LogLevels, string> Map { get; } = new Dictionary<LogLevels, string>
		{
			[LogLevels.Trace] = "TRACE",
			[LogLevels.Debug] = "DEBUG",
			[LogLevels.Info] = "INFO"
		};

		public override string Description => "log level";
	}
}
