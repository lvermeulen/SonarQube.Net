using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetUserTokensUrl() => GetBaseUrl("/api/user_tokens");

		private IFlurlRequest GetUserTokensUrl(string path) => GetUserTokensUrl().AppendPathSegment(path);

		public async Task<GeneratedUserToken> GenerateUserTokenAsync(string name, string login = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(login)] = login
			};

			var response = await GetUserTokensUrl("generate")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<GeneratedUserToken>(response).ConfigureAwait(false);
		}

		public async Task<bool> RevokeUserTokenAsync(string name, string login = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(login)] = login
			};

			var response = await GetUserTokensUrl("revoke")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<UserTokensList> SearchUserTokensAsync(string login = null)
		{
			return await GetUserTokensUrl("search")
				.SetQueryParam(nameof(login), login)
				.GetJsonAsync<UserTokensList>()
				.ConfigureAwait(false);
		}
	}
}
