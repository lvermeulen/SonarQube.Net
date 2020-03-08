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
		private IFlurlRequest GetComponentsUrl() => GetBaseUrl("/api/components");

		private IFlurlRequest GetComponentsUrl(string path) => GetComponentsUrl().AppendPathSegment(path);

		public async Task<IEnumerable<Component>> SearchComponentsAsync(ComponentQualifiers[] qualifiers, string language = null, int? p = null, int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ComponentQualifiersConverter.ToString)),
				[nameof(language)] = language,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetComponentsUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<Component>>("components")
				.ConfigureAwait(false);
		}

		public async Task<FullComponentWithAncestors> ShowComponentAsync(string component)
		{
			return await GetComponentsUrl("show")
				.SetQueryParam(nameof(component), component)
				.GetJsonAsync<FullComponentWithAncestors>()
				.ConfigureAwait(false);
		}

		public async Task<ComponentsTree> GetComponentsTreeAsync(string component, bool? asc = null, int? p = null, int? ps = null, string q = null, ComponentQualifiers[] qualifiers = null, string[] s = null, ComponentTreeStrategies? strategy = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(component)] = component,
				[nameof(asc)] = asc,
				[nameof(p)] = p,
				[nameof(ps)] = ps,
				[nameof(q)] = q,
				[nameof(qualifiers)] = qualifiers == null ? null : string.Join(",", qualifiers.Select(ComponentQualifiersConverter.ToString)),
				[nameof(s)] = s == null ? null : string.Join(",", s),
				[nameof(strategy)] = ComponentTreeStrategiesToStringConverter.ToString(strategy)
			};

			return await GetComponentsUrl("tree")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<ComponentsTree>()
				.ConfigureAwait(false);
		}
	}
}
