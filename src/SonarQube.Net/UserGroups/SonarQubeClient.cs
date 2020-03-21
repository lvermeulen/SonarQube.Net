using System.Collections.Generic;
using System.Linq;
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
		private IFlurlRequest GetUserGroupsUrl() => GetBaseUrl("/api/user_groups");

		private IFlurlRequest GetUserGroupsUrl(string path) => GetUserGroupsUrl().AppendPathSegment(path);

		public async Task<bool> AddUserToUserGroupAsync(int? id = null, string login = null, string name = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(login)] = login,
				[nameof(name)] = name
			};

			var response = await GetUserGroupsUrl("add_user")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<UserGroup> CreateUserGroupAsync(string name, string description = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(description)] = description
			};

			var response = await GetUserGroupsUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<UserGroup>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteUserGroupAsync(int? id = null, string name = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(name)] = name
			};

			var response = await GetUserGroupsUrl("delete")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveUserFromUserGroupAsync(int? id = null, string login = null, string name = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(login)] = login,
				[nameof(name)] = name
			};

			var response = await GetUserGroupsUrl("remove_user")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<UserGroup>> SearchUserGroupsAsync(UserGroupFields[] f = null, int? p = null, int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(f)] = f == null ? null : string.Join(",", f.Select(UserGroupFieldsConverter.ToString)),
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetUserGroupsUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<UserGroup>>("groups")
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateUserGroupAsync(int id, string description = null, string name = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(description)] = description,
				[nameof(name)] = name
			};

			var response = await GetUserGroupsUrl("update")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<SelectedUser>> GetUserGroupUsersAsync(int? id = null, string name = null, int? p = null, int? ps = null, string q = null, SelectedTypes? selected = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(name)] = name,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(selected)] = SelectedTypesConverter.ToString(selected),
			};

			return await GetUserGroupsUrl("users")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<SelectedUser>>("users")
				.ConfigureAwait(false);
		}
	}
}
