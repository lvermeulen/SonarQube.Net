using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SonarQube.Net.Common.Converters
{
	public abstract class JsonEnumConverter<TEnum> : JsonConverter
		where TEnum : struct, IConvertible
	{
		protected abstract Dictionary<TEnum, string> Map { get; }

		protected abstract string Description { get; }

		protected virtual string ConvertToString(TEnum value)
		{
			if (!Map.TryGetValue(value, out string result))
			{
				throw new ArgumentException($"Unknown {Description}: {value}");
			}

			return result;
		}

		protected virtual TEnum ConvertFromString(string s)
		{
			var pair = Map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
			// ReSharper disable once SuspiciousTypeConversion.Global
			if (EqualityComparer<KeyValuePair<TEnum, string>>.Default.Equals(pair))
			{
				throw new ArgumentException($"Unknown {Description}: {s}");
			}

			return pair.Key;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var actualValue = (TEnum)value;
			writer.WriteValue(ConvertToString(actualValue));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartArray)
			{
				var items = new List<TEnum>();
				var array = JArray.Load(reader);
				items.AddRange(array.Select(x => ConvertFromString(x.ToString())));

				return items;
			}

			string s = (string)reader.Value;
			return ConvertFromString(s);
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}
	}
}
