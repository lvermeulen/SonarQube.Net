using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace SonarQube.Net.Common
{
	public static class FlurlRequestExtensions
	{
		public static async Task<T> GetJsonFirstNodeAsync<T>(this IFlurlRequest request, CancellationToken cancellationToken = default, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			var responseMessage = await request.SendAsync(HttpMethod.Get, null, cancellationToken, completionOption).ConfigureAwait(false);
			if (responseMessage == null)
			{
				return default;
			}

			var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			IList<JToken> jobj = JObject.Parse(responseString);

			return ((JProperty)jobj[0]).Value.ToObject<T>();
		}
	}
}
