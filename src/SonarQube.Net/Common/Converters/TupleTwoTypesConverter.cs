using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SonarQube.Net.Common.Converters
{
	public class TupleTwoTypesConverter<T1, T2> : TupleTypesConverter
	{
		public override Type CanConvertType { get; } = typeof(Tuple<T1, T2>);

		public override object ReadJsonInternal(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			const int maxCount = 2;

			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}

			var jArray = JArray.Load(reader);
			var children = jArray.Children<JToken>().ToList();
			if (children.Count != maxCount)
			{
				return null;
			}

			var types = new[] { typeof(T1), typeof(T2) };
			string[] values = new string[maxCount];
			for (int i = 0; i < children.Count; i++)
			{
				var child = children[i];
				values[i] = child.Value<string>();
			}

			return new Tuple<T1, T2>(ChangeType<T1>(values[0], types[0]), ChangeType<T2>(values[1], types[1]));
		}
	}
}
