using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetUsersUrl() => GetBaseUrl("/api/users");

		private IFlurlRequest GetUsersUrl(string path) => GetUsersUrl().AppendPathSegment(path);

		public async Task<bool> ChangeUserPasswordAsync(string login, string password, string previousPassword = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(password)] = password,
				[nameof(previousPassword)] = previousPassword
			};

			var response = await GetUsersUrl("change_password")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<User> CreateUserAsync(string login, string name, string email = null, bool? local = null, string password = null, string[] scmAccount = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(name)] = name,
				[nameof(email)] = email,
				[nameof(local)] = local,
				[nameof(password)] = password,
				[nameof(scmAccount)] = scmAccount
			};

			var response = await GetUsersUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<User>(response).ConfigureAwait(false);
		}

		public async Task<User> DeactivateUserAsync(string login)
		{
			var response = await GetUsersUrl("deactivate")
				.SetQueryParam(nameof(login), login)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<User>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<UserGroup>> GetUserGroupsAsync(string login, int? p = null, int? ps = null, string q = null, SelectedTypes? selected = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(selected)] = SelectedTypesConverter.ToString(selected)
			};

			return await GetUsersUrl("groups")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<UserGroup>>("groups")
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<User>> SearchUsersAsync(int? p = null, int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetUsersUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<User>>("users")
				.ConfigureAwait(false);
		}

		public async Task<User> UpdateUserAsync(string login, string email = null, string name = null, string[] scmAccount = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(email)] = email,
				[nameof(name)] = name,
				[nameof(scmAccount)] = scmAccount
			};

			var response = await GetUsersUrl("update")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<User>(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdateUserLoginAsync(string login, string newLogin)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(newLogin)] = newLogin
			};

			var response = await GetUsersUrl("update_login")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
