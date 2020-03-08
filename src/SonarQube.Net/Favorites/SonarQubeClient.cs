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
		private IFlurlRequest GetFavoritesUrl() => GetBaseUrl("/api/favorites");

		private IFlurlRequest GetFavoritesUrl(string path) => GetFavoritesUrl().AppendPathSegment(path);

		public async Task<bool> AddFavoriteAsync(string component)
		{
			var response = await GetFavoritesUrl("add")
				.SetQueryParam(nameof(component), component)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<bool> RemoveFavoriteAsync(string component)
		{
			var response = await GetFavoritesUrl("remove")
				.SetQueryParam(nameof(component), component)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<IEnumerable<Favorite>> SearchFavoritesAsync(int? p = null, int? ps = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(p)] = p,
				[nameof(ps)] = ps
			};

			return await GetFavoritesUrl("search")
				.SetQueryParams(queryParamValues)
				.GetJsonNamedNodeAsync<IEnumerable<Favorite>>("favorites")
				.ConfigureAwait(false);
		}
	}
}
