using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetAuthenticationUrl() => GetBaseUrl("/api/authentication");

		private IFlurlRequest GetAuthenticationUrl(string path) => GetAuthenticationUrl().AppendPathSegment(path);

		public async Task<bool> LoginAsync(string login, string password)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(password)] = password
			};

			var response = await GetAuthenticationUrl("login")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> LogoutAsync()
		{
			var response = await GetAuthenticationUrl("logout")
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> ValidateCredentialsAsync()
		{
			return await GetAuthenticationUrl("validate")
				.GetJsonFirstNodeAsync<bool>()
				.ConfigureAwait(false);
		}
	}
}
