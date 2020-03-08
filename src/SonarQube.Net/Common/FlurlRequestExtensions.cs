using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace SonarQube.Net.Common
{
	public static class FlurlRequestExtensions
	{
		internal static IList<JToken> GetJsonTokens(this string json) => JObject.Parse(json);

		internal static JProperty GetJsonPropertyByIndex(this IList<JToken> tokens, int index) => (JProperty) tokens[index];

		internal static JProperty GetJsonPropertyByName(this IList<JToken> tokens, string name) => tokens
			.OfType<JProperty>()
			.FirstOrDefault(x => x.Name == name);

		private static async Task<IList<JToken>> GetJsonTokensAsync(this IFlurlRequest request, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var responseMessage = await request.SendAsync(HttpMethod.Get, null, cancellationToken, completionOption).ConfigureAwait(false);
			if (responseMessage == null)
			{
				return default;
			}

			string responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return responseString.GetJsonTokens();
		}

		private static async Task<JProperty> GetJsonNodeAsync(this IFlurlRequest request, int index, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var tokens = await request.GetJsonTokensAsync(cancellationToken, completionOption).ConfigureAwait(false);
			return tokens.GetJsonPropertyByIndex(index);
		}

		private static async Task<JProperty> GetJsonNodeAsync(this IFlurlRequest request, string nodeName, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var tokens = await request.GetJsonTokensAsync(cancellationToken, completionOption).ConfigureAwait(false);
			return tokens.GetJsonPropertyByName(nodeName);
		}

		public static async Task<T> GetJsonFirstNodeAsync<T>(this IFlurlRequest request, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var jproperty = await request.GetJsonNodeAsync(0, cancellationToken, completionOption).ConfigureAwait(false);
			return jproperty.Value.ToObject<T>();
		}

		public static async Task<T> GetJsonNamedNodeAsync<T>(this IFlurlRequest request, string nodeName, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var jproperty = await request.GetJsonNodeAsync(nodeName, cancellationToken, completionOption).ConfigureAwait(false);
			return jproperty.Value.ToObject<T>();
		}
	}
}
