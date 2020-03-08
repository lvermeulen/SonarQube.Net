using System.Collections.Generic;

namespace SonarQube.Net.Common.Converters
{
	public interface IStringConverter<TEnum>
	{
		Dictionary<TEnum, string> Map { get; }

		string Description { get; }

		string ConvertToString(TEnum value);
	}
}