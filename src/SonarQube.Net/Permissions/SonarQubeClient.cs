using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetPermissionsUrl() => GetBaseUrl("/api/permissions");

		private IFlurlRequest GetPermissionsUrl(string path) => GetPermissionsUrl().AppendPathSegment(path);

		public async Task<bool> AddGroupPermissionAsync(string permission, string groupId = null, string groupName = null, string projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(groupId)] = groupId,
				[nameof(groupName)] = groupName,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetPermissionsUrl("add_group")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> AddGroupToPermissionTemplateAsync(string permission, string groupId = null, string groupName = null, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(groupId)] = groupId,
				[nameof(groupName)] = groupName,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("add_group_to_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> AddProjectCreatorToPermissionTemplateAsync(string permission, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("add_project_creator_to_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> AddUserPermissionAsync(string login, string permission, string projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(permission)] = permission,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetPermissionsUrl("add_user")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> AddUserToPermissionTemplateAsync(string login, string permission, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(permission)] = permission,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("add_user_to_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> ApplyPermissionTemplateAsync(string projectId = null, string projectKey = null, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("apply_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> BulkApplyPermissionTemplateAsync(DateTime? analyzedBefore = null, bool? onProvisionedOnly = null, string[] projects = null, string q = null, ComponentQualifiers[] qualifiers = null, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(analyzedBefore)] = DateTimeToStringConverter.ToString(analyzedBefore),
				[nameof(onProvisionedOnly)] = onProvisionedOnly,
				[nameof(projects)] = projects == null ? null : string.Join(",", projects),
				[nameof(q)] = q,
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ComponentQualifiersConverter.ToString)),
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("bulk_apply_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<PermissionTemplateReference> CreatePermissionTemplateAsync(string name, string description = null, string projectKeyPattern = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(description)] = description,
				[nameof(projectKeyPattern)] = projectKeyPattern
			};

			var response = await GetPermissionsUrl("create_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<PermissionTemplateReference>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeletePermissionTemplateAsync(string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("delete_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveGroupPermissionAsync(string permission, string groupId = null, string groupName = null, string projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(groupId)] = groupId,
				[nameof(groupName)] = groupName,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetPermissionsUrl("remove_group")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveGroupFromPermissionTemplateAsync(string permission, string groupId = null, string groupName = null, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(groupId)] = groupId,
				[nameof(groupName)] = groupName,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("remove_group_from_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveProjectCreatorFromPermissionTemplateAsync(string permission, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(permission)] = permission,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("remove_project_creator_from_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveUserPermissionAsync(string login, string permission, string projectId = null, string projectKey = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(permission)] = permission,
				[nameof(projectId)] = projectId,
				[nameof(projectKey)] = projectKey
			};

			var response = await GetPermissionsUrl("remove_user")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveUserFromPermissionTemplateAsync(string login, string permission, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(login)] = login,
				[nameof(permission)] = permission,
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("remove_user_from_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<PermissionTemplatesList> SearchPermissionTemplatesAsync(string q = null)
		{
			return await GetPermissionsUrl("search_templates")
				.SetQueryParam(nameof(q), q)
				.GetJsonAsync<PermissionTemplatesList>()
				.ConfigureAwait(false);
		}

		public async Task<bool> SetDefaultPermissionTemplateAsync(ComponentQualifiers? qualifier = null, string templateId = null, string templateName = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(qualifier)] = ComponentQualifiersConverter.ToString(qualifier),
				[nameof(templateId)] = templateId,
				[nameof(templateName)] = templateName
			};

			var response = await GetPermissionsUrl("set_default_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<UpdatedPermissionTemplate> UpdatePermissionTemplateAsync(string id, string description = null, string name = null, string projectKeyPattern = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(id)] = id,
				[nameof(description)] = description,
				[nameof(name)] = name,
				[nameof(projectKeyPattern)] = projectKeyPattern
			};

			var response = await GetPermissionsUrl("update_template")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<UpdatedPermissionTemplate>(response).ConfigureAwait(false);
		}
	}
}
