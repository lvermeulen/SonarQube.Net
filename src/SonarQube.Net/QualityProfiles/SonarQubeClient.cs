using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Flurl.Http;
using Flurl.Http.Xml;
using SonarQube.Net.Common;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetQualityProfilesUrl() => GetBaseUrl("/api/qualityprofiles");

		private IFlurlRequest GetQualityProfilesUrl(string path) => GetQualityProfilesUrl().AppendPathSegment(path);

		public async Task<bool> ActivateQualityProfileRuleAsync(string key, string rule, IDictionary<string, string> parameters = null, bool? reset = null, Severities? severity = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(rule)] = rule,
				["params"] = parameters, // XXX
				[nameof(reset)] = BooleanConverter.ToString(reset),
				[nameof(severity)] = SeveritiesConverter.ToString(severity)
			};

			var response = await GetQualityProfilesUrl("activate_rule")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> ActivateQualityProfileRulesAsync(string targetKey, bool? activation = null, Severities[] activeSeverities = null, bool? asc = null,
			DateTime? availableSince = null, string[] cwe = null, RuleInheritanceTypes[] inheritance = null, bool? isTemplate = null, string[] languages = null,
			OwaspTop10Types[] owaspTop10 = null, string q = null, string qprofile = null, string[] repositories = null, string ruleKey = null, RuleSortFields? s = null,
			SansTop25Types[] sansTop25 = null, Severities[] severities = null, SonarSourceSecurityTypes[] sonarSourceSecurity = null, RuleStatuses[] statuses = null,
			string[] tags = null, Severities? targetSeverity = null, string templateKey = null, IssueTypes[] types = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(targetKey)] = targetKey,
				[nameof(activation)] = BooleanConverter.ToString(activation),
				["active_severities"] = activeSeverities,
				[nameof(asc)] = BooleanConverter.ToString(asc),
				["available_since"] = DateTimeToStringConverter.ToString(availableSince, "yyyy-MM-dd"),
				[nameof(cwe)] = cwe == null ? null : string.Join(",", cwe),
				[nameof(inheritance)] = inheritance == null ? null : string.Join(",", inheritance.Select(RuleInheritanceTypesConverter.ToString)),
				["is_template"] = BooleanConverter.ToString(isTemplate),
				[nameof(languages)] = languages == null ? null : string.Join(",", languages),
				[nameof(owaspTop10)] = owaspTop10 == null ? null : string.Join(",", owaspTop10.Select(OwaspTop10TypesConverter.ToString)),
				[nameof(q)] = q,
				[nameof(qprofile)] = qprofile,
				[nameof(repositories)] = repositories == null ? null : string.Join(",", repositories),
				["rule_key"] = ruleKey,
				[nameof(s)] = s == null ? null : string.Join(",", s),
				[nameof(sansTop25)] = sansTop25 == null ? null : string.Join(",", sansTop25.Select(SansTop25TypesConverter.ToString)),
				[nameof(severities)] = severities == null ? null : string.Join(",", severities.Select(SeveritiesConverter.ToString)),
				[nameof(sonarSourceSecurity)] = sonarSourceSecurity == null ? null : string.Join(",", sonarSourceSecurity.Select(SonarSourceSecurityTypesConverter.ToString)),
				[nameof(statuses)] = statuses == null ? null : string.Join(",", statuses.Select(RuleStatusesConverter.ToString)),
				[nameof(tags)] = tags == null ? null : string.Join(",", tags),
				[nameof(targetSeverity)] = SeveritiesConverter.ToString(targetSeverity),
				["template_key"] = templateKey,
				[nameof(types)] = types == null ? null : string.Join(",", types.Select(IssueTypesConverter.ToString))
			};

			var response = await GetQualityProfilesUrl("activate_rules")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> AddProjectToQualityProfileAsync(string language, string project, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(project)] = project,
				[nameof(qualityProfile)] = qualityProfile
			};

			var response = await GetQualityProfilesUrl("add_project")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<XDocument> BackupQualityProfileAsync(string language, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile
			};

			return await GetQualityProfilesUrl("backup")
				.SetQueryParams(queryParamValues)
				.GetXDocumentAsync()
				.ConfigureAwait(false);
		}

		public async Task<bool> ChangeQualityProfileParentAsync(string language, string qualityProfile, string parentQualityProfile = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile,
				[nameof(parentQualityProfile)] = parentQualityProfile
			};

			var response = await GetQualityProfilesUrl("change_parent")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<QualityProfilesChangeLog>> GetQualityProfileChangeLogsAsync(string language, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile
			};

			return await GetQualityProfilesUrl("changelog")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<QualityProfilesChangeLog>>("events")
				.ConfigureAwait(false);
		}

		public async Task<QualityProfileRef> CopyQualityProfileAsync(string fromKey, string toKey)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(fromKey)] = fromKey,
				[nameof(toKey)] = toKey
			};

			var response = await GetQualityProfilesUrl("copy")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<QualityProfileRef>(response).ConfigureAwait(false);
		}

		public async Task<CreatedQualityProfile> CreateQualityProfileAsync(string language, string name, string backupSonarlintVsCsFake = null, string backupSonarlintVsVbnetFake = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(name)] = name,
				["backup_sonarlint-vs-cs-fake"] = backupSonarlintVsCsFake,
				["backup_sonarlint-vs-vbnet-fake"] = backupSonarlintVsVbnetFake
			};

			var response = await GetQualityProfilesUrl("create")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync<CreatedQualityProfile>(response).ConfigureAwait(false);
		}

		public async Task<bool> DeactivateQualityProfileRuleAsync(string key, string rule)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(rule)] = rule
			};

			var response = await GetQualityProfilesUrl("deactivate_rule")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeactivateQualityProfileRulesAsync(string targetKey, bool? activation = null, Severities[] activeSeverities = null, bool? asc = null,
			DateTime? availableSince = null, string[] cwe = null, RuleInheritanceTypes[] inheritance = null, bool? isTemplate = null, string[] languages = null,
			OwaspTop10Types[] owaspTop10 = null, string q = null, string qprofile = null, string[] repositories = null, string ruleKey = null, RuleSortFields? s = null,
			SansTop25Types[] sansTop25 = null, Severities[] severities = null, SonarSourceSecurityTypes[] sonarSourceSecurity = null, RuleStatuses[] statuses = null,
			string[] tags = null, string templateKey = null, IssueTypes[] types = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(targetKey)] = targetKey,
				[nameof(activation)] = BooleanConverter.ToString(activation),
				["active_severities"] = activeSeverities,
				[nameof(asc)] = BooleanConverter.ToString(asc),
				["available_since"] = DateTimeToStringConverter.ToString(availableSince, "yyyy-MM-dd"),
				[nameof(cwe)] = cwe == null ? null : string.Join(",", cwe),
				[nameof(inheritance)] = inheritance == null ? null : string.Join(",", inheritance.Select(RuleInheritanceTypesConverter.ToString)),
				["is_template"] = BooleanConverter.ToString(isTemplate),
				[nameof(languages)] = languages == null ? null : string.Join(",", languages),
				[nameof(owaspTop10)] = owaspTop10 == null ? null : string.Join(",", owaspTop10.Select(OwaspTop10TypesConverter.ToString)),
				[nameof(q)] = q,
				[nameof(qprofile)] = qprofile,
				[nameof(repositories)] = repositories == null ? null : string.Join(",", repositories),
				["rule_key"] = ruleKey,
				[nameof(s)] = s == null ? null : string.Join(",", s),
				[nameof(sansTop25)] = sansTop25 == null ? null : string.Join(",", sansTop25.Select(SansTop25TypesConverter.ToString)),
				[nameof(severities)] = severities == null ? null : string.Join(",", severities.Select(SeveritiesConverter.ToString)),
				[nameof(sonarSourceSecurity)] = sonarSourceSecurity == null ? null : string.Join(",", sonarSourceSecurity.Select(SonarSourceSecurityTypesConverter.ToString)),
				[nameof(statuses)] = statuses == null ? null : string.Join(",", statuses.Select(RuleStatusesConverter.ToString)),
				[nameof(tags)] = tags == null ? null : string.Join(",", tags),
				["template_key"] = templateKey,
				[nameof(types)] = types == null ? null : string.Join(",", types.Select(IssueTypesConverter.ToString))
			};

			var response = await GetQualityProfilesUrl("deactivate_rules")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> DeleteQualityProfileAsync(string language, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile
			};

			var response = await GetQualityProfilesUrl("delete")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<XDocument> ExportQualityProfileAsync(string language, QualityProfileExporterKeys? exporterKey = null, string qualityProfile = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(exporterKey)] = QualityProfileExporterKeysConverter.ToString(exporterKey),
				[nameof(qualityProfile)] = qualityProfile
			};

			return await GetQualityProfilesUrl("export")
				.SetQueryParams(queryParamValues)
				.GetXDocumentAsync()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<QualityProfileImporterExporter>> GetQualityProfileExportersAsync()
		{
			return await GetQualityProfilesUrl("exporters")
				.GetJsonFirstNodeAsync<IEnumerable<QualityProfileImporterExporter>>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<QualityProfileImporterExporter>> GetQualityProfileImportersAsync()
		{
			return await GetQualityProfilesUrl("importers")
				.GetJsonFirstNodeAsync<IEnumerable<QualityProfileImporterExporter>>()
				.ConfigureAwait(false);
		}

		public async Task<QualityProfileInheritance> GetQualityProfileInheritanceAsync(string language, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile
			};

			return await GetQualityProfilesUrl("inheritance")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<QualityProfileInheritance>()
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<QualityProfileProjectStatus>> GetQualityProfileProjectsStatusAsync(string key, int? p = null, int? ps = null, string q = null, SelectedTypes? selected = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(selected)] = SelectedTypesConverter.ToString(selected)
			};

			return await GetQualityProfilesUrl("projects")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<QualityProfileProjectStatus>>("results")
				.ConfigureAwait(false);
		}

		public async Task<bool> RemoveProjectFromQualityProfileAsync(string language, string project, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(project)] = project,
				[nameof(qualityProfile)] = qualityProfile
			};

			var response = await GetQualityProfilesUrl("remove_project")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RenameQualityProfileAsync(string key, string name)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(key)] = key,
				[nameof(name)] = name
			};

			var response = await GetQualityProfilesUrl("rename")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RestoreQualityProfileAsync(XDocument backup)
		{
			var response = await GetQualityProfilesUrl("restore")
				.SetQueryParam(nameof(backup), backup)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<SearchQualityProfiles> SearchQualityProfilesAsync(bool? defaults = null, string language = null, string project = null, string qualityProfile = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(defaults)] = BooleanConverter.ToString(defaults),
				[nameof(language)] = language,
				[nameof(project)] = project,
				[nameof(qualityProfile)] = qualityProfile
			};

			return await GetQualityProfilesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<SearchQualityProfiles>()
				.ConfigureAwait(false);
		}

		public async Task<bool> SetQualityProfileAsDefaultAsync(string language, string qualityProfile)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(language)] = language,
				[nameof(qualityProfile)] = qualityProfile
			};

			var response = await GetQualityProfilesUrl("set_default")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
