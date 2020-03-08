using System;
using System.Collections.Generic;

namespace SonarQube.Net.Common.Converters
{
	public abstract class StringConverter<TEnum> : IStringConverter<TEnum>
	{
		public abstract Dictionary<TEnum, string> Map { get; }

		public abstract string Description { get; }

		public virtual string ConvertToString(TEnum value)
		{
			if (!Map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown {Description}: {value}");
			}

			return result;
		}
	}
}