using System;

namespace SonarQube.Net.Common.Converters
{
	public static class DateTimeToStringConverter
	{
		public static string ToString(DateTime value)
		{
			return value.ToString("O");
		}

		public static string ToString(DateTime value, string format)
		{
			return value.ToString(format);
		}

		public static string ToString(DateTime? value)
		{
			return value.HasValue
				? ToString(value.Value)
				: null;
		}

		public static string ToString(DateTime? value, string format)
		{
			return value.HasValue
				? ToString(value.Value, format)
				: null;
		}
	}
}
