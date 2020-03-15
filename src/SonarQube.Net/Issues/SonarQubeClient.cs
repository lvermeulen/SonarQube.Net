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
		private IFlurlRequest GetIssuesUrl() => GetBaseUrl("/api/issues");

		private IFlurlRequest GetIssuesUrl(string path) => GetIssuesUrl().AppendPathSegment(path);

		public async Task<Issue> AddIssueCommentAsync(string issue, string text)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(text)] = text
			};

			var response = await GetIssuesUrl("add_comment")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> AssignIssueAsync(string issue, string assignee = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(assignee)] = assignee
			};

			var response = await GetIssuesUrl("assign")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<string>> GetIssueAuthorsAsync(string project = null, int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetIssuesUrl("authors")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<string>>()
				.ConfigureAwait(false);
		}

		public async Task<IssueBulkChange> BulkChangeIssuesAsync(string[] addTags = null, string assign = null, string comment = null, string doTransition = null,
			string[] issues = null, string[] removeTags = null, bool? sendNotifications = null, Severities? setSeverity = null, IssueTypes? type = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["add_tags"] = addTags,
				[nameof(assign)] = assign,
				[nameof(comment)] = comment,
				["do_transition"] = doTransition,
				[nameof(issues)] = issues == null ? null : string.Join(",", issues),
				["remove_tags"] = removeTags,
				[nameof(sendNotifications)] = sendNotifications,
				["set_severity"] = setSeverity,
				["set_type"] = type == null ? null : IssueTypesConverter.ToString(type)
			};

			var response = await GetIssuesUrl("bulk_change")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<IssueBulkChange>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<IssueChangeLog>> GetIssueChangeLogsAsync(string issue)
		{
			return await GetIssuesUrl("changelog")
				.SetQueryParam(nameof(issue), issue)
				.GetJsonFirstNodeAsync<IEnumerable<IssueChangeLog>>()
				.ConfigureAwait(false);
		}

		public async Task<Issue> DeleteIssueCommentAsync(string comment)
		{
			var response = await GetIssuesUrl("delete_comment")
				.SetQueryParam(nameof(comment), comment)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> DoIssueTransitionAsync(string issue, string transition)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(transition)] = transition
			};

			var response = await GetIssuesUrl("do_transition")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> EditIssueCommentAsync(string comment, string text)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(comment)] = comment,
				[nameof(text)] = text
			};

			var response = await GetIssuesUrl("edit_comment")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IssuesList> SearchIssuesAsync(AvailableIssueFields[] additionalFields = null, bool? asc = null, bool? assigned = null, string[] assignees = null,
			string[] author = null, string[] componentKeys = null, DateTime? createdAfter = null, DateTime? createdAt = null, DateTime? createdBefore = null, string createdInLast = null,
			string[] cwe = null, Facets[] facets = null, string[] issues = null, string[] languages = null, bool? onComponentsOnly = null, OwaspTop10Types[] owaspTop10 = null,
			int? p = null, int? ps = null, IssueResolutions[] resolutions = null, bool? resolved = null, string[] rules = null, IssueSortFields[] s = null,
			SansTop25Types[] sansTop25 = null, Severities[] severities = null, bool? sinceLeakPeriod = null, SonarSourceSecurityTypes[] sonarSourceSecurity = null,
			IssueStatuses[] statuses = null, string[] tags = null, IssueTypes[] types = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(additionalFields)] = additionalFields == null ? null : string.Join(",", additionalFields.Select(AvailableIssueFieldsConverter.ToString)),
				[nameof(asc)] = asc,
				[nameof(assigned)] = assigned,
				[nameof(assignees)] = assignees == null ? null : string.Join(",", assignees),
				[nameof(author)] = author,
				[nameof(componentKeys)] = componentKeys == null ? null : string.Join(",", componentKeys),
				[nameof(createdAfter)] = DateTimeToStringConverter.ToString(createdAfter),
				[nameof(createdAt)] = DateTimeToStringConverter.ToString(createdAt),
				[nameof(createdBefore)] = DateTimeToStringConverter.ToString(createdBefore),
				[nameof(createdInLast)] = createdInLast,
				[nameof(cwe)] = cwe == null ? null : string.Join(",", cwe),
				[nameof(facets)] = facets == null ? null : string.Join(",", facets.Select(FacetsConverter.ToString)),
				[nameof(issues)] = issues == null ? null : string.Join(",", issues),
				[nameof(languages)] = languages == null ? null : string.Join(",", languages),
				[nameof(onComponentsOnly)] = onComponentsOnly,
				[nameof(owaspTop10)] = owaspTop10 == null ? null : string.Join(",", owaspTop10.Select(OwaspTop10TypesConverter.ToString)),
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(resolutions)] = resolutions == null ? null : string.Join(",", resolutions.Select(IssueResolutionsConverter.ToString)),
				[nameof(resolved)] = resolved,
				[nameof(rules)] = rules,
				[nameof(s)] = s,
				[nameof(sansTop25)] = sansTop25 == null ? null : string.Join(",", sansTop25.Select(SansTop25TypesConverter.ToString)),
				[nameof(severities)] = severities == null ? null : string.Join(",", severities.Select(SeveritiesConverter.ToString)),
				[nameof(sinceLeakPeriod)] = sinceLeakPeriod,
				[nameof(sonarSourceSecurity)] = sonarSourceSecurity == null ? null : string.Join(",", sonarSourceSecurity.Select(SonarSourceSecurityTypesConverter.ToString)),
				[nameof(statuses)] = statuses == null ? null : string.Join(",", statuses.Select(IssueStatusesConverter.ToString)),
				[nameof(tags)] = tags,
				[nameof(types)] = types == null ? null : string.Join(",", types.Select(IssueTypesConverter.ToString))
			};

			return await GetIssuesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<IssuesList>()
				.ConfigureAwait(false);
		}

		public async Task<Issue> SetIssueSeverityAsync(string issue, Severities severity)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(severity)] = SeveritiesConverter.ToString(severity)
			};

			var response = await GetIssuesUrl("set_severity")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> SetIssueTagsAsync(string issue, params string[] tags)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(tags)] = tags == null ? null : string.Join(",", tags)
			};

			var response = await GetIssuesUrl("set_tags")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<Issue> SetIssueTypeAsync(string issue, IssueTypes type)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(issue)] = issue,
				[nameof(type)] = IssueTypesConverter.ToString(type)
			};

			var response = await GetIssuesUrl("set_type")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Issue>(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<string>> GetIssueTagsAsync(string project = null, int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetIssuesUrl("tags")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<string>>()
				.ConfigureAwait(false);
		}
	}
}
