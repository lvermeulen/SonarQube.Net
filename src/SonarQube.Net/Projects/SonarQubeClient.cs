using System;
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
		private IFlurlRequest GetProjectsUrl() => GetBaseUrl("/api/projects");

		private IFlurlRequest GetProjectsUrl(string path) => GetProjectsUrl().AppendPathSegment(path);

		public async Task<bool> BulkDeleteProjectsAsync(DateTime? analyzedBefore = null, bool? onProvisionedOnly = null, string[] projects = null, string q = null, ProjectQualifiers[] qualifiers = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(analyzedBefore)] = DateTimeToStringConverter.ToString(analyzedBefore),
				[nameof(onProvisionedOnly)] = onProvisionedOnly,
				[nameof(projects)] = projects == null ? null : string.Join(",", projects),
				[nameof(q)] = q,
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ProjectQualifiersConverter.ToString))
			};

			var response = await GetProjectsUrl("bulk_delete")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<Project> CreateProjectAsync(string name, string project, ProjectVisibilities? visibility = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(name)] = name,
				[nameof(project)] = project,
				[nameof(visibility)] = ProjectVisibilitiesConverter.ToString(visibility)
			};

			var response = await GetProjectsUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Project>(response).ConfigureAwait(false);
		}

		public async Task<Project> DeleteProjectAsync(string project)
		{
			var response = await GetProjectsUrl("delete")
				.SetQueryParam(nameof(project), project)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Project>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<ProjectComponent>> SearchProjectsAsync(DateTime? analyzedBefore = null, bool? onProvisionedOnly = null, int? p = null, string[] projects = null, int? ps = null, string q = null, ProjectQualifiers[] qualifiers = null, string organization = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(analyzedBefore)] = DateTimeToStringConverter.ToString(analyzedBefore),
				[nameof(onProvisionedOnly)] = BooleanConverter.ToString(onProvisionedOnly),
				[nameof(p)] = p,
				[nameof(projects)] = projects == null ? null : string.Join(",", projects),
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ProjectQualifiersConverter.ToString)),
				[nameof(organization)] = organization
			};

			return await GetProjectsUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<ProjectComponent>>("components")
				.ConfigureAwait(false);
		}

		public async Task<bool> UpdateProjectKeyAsync(string from, string to)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(from)] = from,
				[nameof(to)] = to
			};

			var response = await GetProjectsUrl("update_key")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> UpdateProjectVisibilityAsync(string project, ProjectVisibilities visibility)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(visibility)] = visibility
			};

			var response = await GetProjectsUrl("update_visibility")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
