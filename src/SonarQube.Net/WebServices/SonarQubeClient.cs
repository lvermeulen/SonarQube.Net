using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetWebServicesUrl() => GetBaseUrl("/api/webservices");

		private IFlurlRequest GetWebServicesUrl(string path) => GetWebServicesUrl().AppendPathSegment(path);

		public async Task<IEnumerable<WebService>> GetWebServicesListAsync(bool? includeInternals = null)
		{
			return await GetWebServicesUrl("list")
				.SetQueryParam("include_internals", includeInternals)
				.GetJsonFirstNodeAsync<IEnumerable<WebService>>()
				.ConfigureAwait(false);
		}

		public async Task<WebServiceResponseExample> GetWebServiceResponseExampleAsync(string action, string controller)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(action)] = action,
				[nameof(controller)] = controller
			};

			return await GetWebServicesUrl("response_example")
				.SetQueryParams(queryParamValues)
				.GetJsonAsync<WebServiceResponseExample>()
				.ConfigureAwait(false);
		}
	}
}
