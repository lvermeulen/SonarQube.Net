using System.Threading.Tasks;
using Flurl.Http;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetServerUrl() => GetBaseUrl("/api/server");

		private IFlurlRequest GetServerUrl(string path) => GetServerUrl().AppendPathSegment(path);

		public async Task<string> GetServerVersionAsync()
		{
			return await GetServerUrl("version")
				.GetStringAsync()
				.ConfigureAwait(false);
		}
	}
}
