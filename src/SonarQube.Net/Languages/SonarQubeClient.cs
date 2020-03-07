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
		private IFlurlRequest GetLanguagesUrl() => GetBaseUrl("/api/languages");

		public async Task<IEnumerable<Language>> GetLanguagesListAsync(int? ps = null, string q = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(ps)] = ps,
				[nameof(q)] = q
			};

			return await GetLanguagesUrl()
				.AppendPathSegment("/list")
				.SetQueryParams(queryParamValues)
				.GetJsonFirstNodeAsync<IEnumerable<Language>>()
				.ConfigureAwait(false);
		}
	}
}
