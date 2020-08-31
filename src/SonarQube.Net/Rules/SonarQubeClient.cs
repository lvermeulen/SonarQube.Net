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
		private IFlurlRequest GetRulesUrl() => GetBaseUrl("/api/rules");

		private IFlurlRequest GetRulesUrl(string path) => GetRulesUrl().AppendPathSegment(path);

		public async Task<Rule> CreateRuleAsync(string customKey, string markdownDescription, string name, IDictionary<string, string> parameters = null, bool? preventReactivation = null,
			Severities? severity = null, RuleStatuses? status = null, string templateKey = null, IssueTypes? type = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				["custom_key"] = customKey,
				["markdown_description"] = markdownDescription,
				[nameof(name)] = name,
				["params"] = parameters?.Select(x => $"{x.Key}={x.Value}"),
				["prevent_reactivation"] = BooleanConverter.ToString(preventReactivation),
				[nameof(severity)] = SeveritiesConverter.ToString(severity),
				[nameof(status)] = RuleStatusesConverter.ToString(status),
				["template_key"] = templateKey,
				[nameof(type)] = IssueTypesConverter.ToString(type)
			};

			var response = await GetRulesUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Rule>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteRuleAsync(string key)
		{
			var response = await GetRulesUrl("delete")
				.SetQueryParam(nameof(key), key)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<RuleRepository>> GetRuleRepositoriesAsync(string language = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(q)] = q
			};

			return await GetRulesUrl("repositories")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<RuleRepository>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Rule>> SearchRulesAsync(bool? activation = null, Severities[] activeSeverities = null, bool? asc = null, DateTime? availableSince = null,
			string[] cwe = null, AvailableRuleFields[] f = null, Facets[] facets = null, bool? includeExternal = null, RuleInheritanceTypes[] inheritance = null, bool? isTemplate = null,
			string[] languages = null, OwaspTop10Types[] owaspTop10 = null, int? p = null, int? ps = null, string q = null, string qprofile = null, string[] repositories = null,
			string ruleKey = null, RuleSortFields? s = null, SansTop25Types[] sansTop25 = null, Severities[] severities = null, SonarSourceSecurityTypes[] sonarSourceSecurity = null,
			RuleStatuses[] statuses = null, string[] tags = null, string templateKey = null, IssueTypes[] types = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(activation)] = BooleanConverter.ToString(activation),
				["active_severities"] = activeSeverities == null ? null : string.Join(",", activeSeverities.Select(SeveritiesConverter.ToString)),
				[nameof(asc)] = BooleanConverter.ToString(asc),
				["available_since"] = DateTimeToStringConverter.ToString(availableSince, "yyyy-MM-dd"),
				[nameof(cwe)] = cwe == null ? null : string.Join(",", cwe),
				[nameof(f)] = f == null ? null : string.Join(",", f.Select(AvailableRuleFieldsConverter.ToString)),
				[nameof(facets)] = facets == null ? null : string.Join(",", facets.Select(FacetsConverter.ToString)),
				["include_external"] = BooleanConverter.ToString(includeExternal),
				[nameof(inheritance)] = inheritance == null ? null : string.Join(",", string.Join(",", inheritance.Select(RuleInheritanceTypesConverter.ToString))),
				["is_template"] = BooleanConverter.ToString(isTemplate),
				[nameof(languages)] = languages == null ? null : string.Join(",", languages),
				[nameof(owaspTop10)] = owaspTop10 == null ? null : string.Join(",", owaspTop10.Select(OwaspTop10TypesConverter.ToString)),
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(qprofile)] = qprofile,
				[nameof(repositories)] = repositories == null ? null : string.Join(",", repositories),
				["rule_key"] = ruleKey,
				[nameof(s)] = s == null ? null : RuleSortFieldsConverter.ToString(s),
				[nameof(sansTop25)] = sansTop25 == null ? null : string.Join(",", sansTop25.Select(SansTop25TypesConverter.ToString)),
				[nameof(severities)] = severities == null ? null : string.Join(",", severities.Select(SeveritiesConverter.ToString)),
				[nameof(sonarSourceSecurity)] = sonarSourceSecurity == null ? null : string.Join(",", sonarSourceSecurity.Select(SonarSourceSecurityTypesConverter.ToString)),
				[nameof(statuses)] = statuses == null ? null : string.Join(",", statuses.Select(RuleStatusesConverter.ToString)),
				[nameof(tags)] = tags == null ? null : string.Join(",", tags),
				["template_key"] = templateKey,
				[nameof(types)] = types == null ? null : string.Join(",", types.Select(IssueTypesConverter.ToString))
			};

			return await GetRulesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<Rule>>("rules")
				.ConfigureAwait(false);
		}

		public async Task<Rule> ShowRuleAsync(string key, bool? actives = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(actives)] = BooleanConverter.ToString(actives)
			};

			return await GetRulesUrl("show")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<Rule>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<string>> GetRuleTagsAsync(int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetRulesUrl("tags")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<string>>()
				.ConfigureAwait(false);
		}

		public async Task<Rule> UpdateRuleAsync(string key, string markdownDescription = null, string markdownNote = null, string name = null, IDictionary<string, string> parameters = null,
			string remediationFnBaseEffort = null, RemediationFunctionTypes? remediationFnType = null, string remediationFyGapMultiplier = null, Severities? severity = null,
			RuleStatuses? status = null, string[] tags = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				["markdown_description"] = markdownDescription,
				["markdown_note"] = markdownNote,
				[nameof(name)] = name,
				["params"] = parameters?.Select(x => $"{x.Key}={x.Value}"),
				["remediation_fn_base_effort"] = remediationFnBaseEffort,
				["remediation_fn_type"] = RemediationFunctionTypesConverter.ToString(remediationFnType),
				["remediation_fy_gap_multiplier_"] = remediationFyGapMultiplier,
				[nameof(severity)] = SeveritiesConverter.ToString(severity),
				[nameof(status)] = RuleStatusesConverter.ToString(status),
				[nameof(tags)] = tags == null ? null : string.Join(",", tags)
			};

			var response = await GetRulesUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseFirstNodeAsync<Rule>(response).ConfigureAwait(false);
		}
	}
}
