using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetDuplicationsUrl() => GetBaseUrl("/api/duplications");

		private IFlurlRequest GetDuplicationsUrl(string path) => GetDuplicationsUrl().AppendPathSegment(path);

		public async Task<DuplicationsList> ShowDuplicationsAsync(string key)
		{
			return await GetDuplicationsUrl("show")
				.SetQueryParam(nameof(key), key)
				.GetJsonAsync<DuplicationsList>()
				.ConfigureAwait(false);
		}
	}
}
