using System;
using Newtonsoft.Json;

namespace SonarQube.Net.Common.Converters
{
	public abstract class TupleTypesConverter : JsonConverter
	{
		public abstract Type CanConvertType { get; }

		public override bool CanConvert(Type objectType)
		{
			return CanConvertType == objectType;
		}

		protected T ChangeType<T>(string value, Type type)
		{
			return (T)Convert.ChangeType(value, type);
		}

		public abstract object ReadJsonInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return ReadJsonInternal(reader, objectType, existingValue, serializer);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}
	}
}
