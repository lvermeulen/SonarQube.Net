using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetServerUrl() => GetBaseUrl("/api/server");

		public async Task<string> GetServerVersionAsync()
		{
			return await GetServerUrl()
				.AppendPathSegment("/version")
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}
