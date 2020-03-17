using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Flurl.Http;
using Flurl.Http.Xml;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetProjectBadgesUrl() => GetBaseUrl("/api/project_badges");

		private IFlurlRequest GetProjectBadgesUrl(string path) => GetProjectBadgesUrl().AppendPathSegment(path);

		public async Task<XDocument> GenerateMeasureBadgeAsync(string project, BadgeMetricTypes metric, string branch = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(metric)] = BadgeMetricTypesConverter.ToString(metric),
				[nameof(branch)] = branch
			};

			return await GetProjectBadgesUrl("measure")
				.SetQueryParams(queryParamValues)
				.GetXDocumentAsync()
				.ConfigureAwait(false);
		}

		public async Task<XDocument> GenerateQualityGateBadgeAsync(string project, string branch = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(project)] = project,
				[nameof(branch)] = branch
			};

			return await GetProjectBadgesUrl("quality_gate")
				.SetQueryParams(queryParamValues)
				.GetXDocumentAsync()
				.ConfigureAwait(false);
		}
	}
}
