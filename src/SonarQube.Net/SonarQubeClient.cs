using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SonarQube.Net.Common;
using SonarQube.Net.Common.Authentication;
using SonarQube.Net.Common.Models;

namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
		private static readonly HttpContent s_emptyHttpContent = null;

		private readonly Url _url;
		private readonly AuthenticationMethod _auth;

		private readonly Func<HttpCall, Task> _errorHandlerAsync = async call =>
		{
			if (call?.Response == null || !call.Completed)
			{
				return;
			}

			string body = await call.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
			var sonarQubeErrors = call.FlurlRequest.Settings.JsonSerializer.Deserialize<SonarQubeErrors>(body);
			var exception = new InvalidOperationException(sonarQubeErrors.Errors.FirstOrDefault()?.Msg);

			throw exception;
		};

		public SonarQubeClient(string url)
		{
			FlurlHttp.GlobalSettings.OnErrorAsync = _errorHandlerAsync;

			_url = url;
		}

		public SonarQubeClient(string url, BasicAuthentication basic)
			: this(url)
		{
			_auth = basic;
		}

		public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
			.AppendPathSegment(path)
			.ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
			.WithAuthentication(_auth);

		private async Task<TResult> ReadResponseContentAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
		{
			string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return contentHandler != null
				? contentHandler(content)
				: JsonConvert.DeserializeObject<TResult>(content);
		}

		private async Task<TResult> ReadResponseContentFirstNodeAsync<TResult>(HttpResponseMessage responseMessage, int index = 0)
		{
			string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			var tokens = content.GetJsonTokens();
			var jproperty = tokens.GetJsonPropertyByIndex(index);

			return jproperty.Value.ToObject<TResult>();
		}

		private async Task<bool> ReadResponseContentAsync(HttpResponseMessage responseMessage)
		{
			string content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return content.Length == 0;
		}

		private async Task HandleErrorsAsync(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var sonarQubeErrors = await ReadResponseContentAsync<SonarQubeErrors>(response).ConfigureAwait(false);

				// ReSharper disable once AssignNullToNotNullAttribute
				string errorMessage = string.Join(Environment.NewLine, sonarQubeErrors?.Errors?.Select(x => x.Msg));
				throw new InvalidOperationException($"Http request failed ({(int)response.StatusCode} - {response.StatusCode}):\n{errorMessage}");
			}
		}

		private async Task<TResult> HandleResponseAsync<TResult>(HttpResponseMessage responseMessage, Func<string, TResult> contentHandler = null)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage, contentHandler).ConfigureAwait(false);
		}

		private async Task<TResult> HandleResponseFirstNodeAsync<TResult>(HttpResponseMessage responseMessage)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentFirstNodeAsync<TResult>(responseMessage).ConfigureAwait(false);
		}

		private async Task<bool> HandleResponseAsync(HttpResponseMessage responseMessage)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage).ConfigureAwait(false);
		}
	}
}
