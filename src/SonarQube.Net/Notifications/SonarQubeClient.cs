using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using SonarQube.Net.Common.Converters;
using SonarQube.Net.Models;

// ReSharper disable once CheckNamespace
namespace SonarQube.Net
{
	public partial class SonarQubeClient
	{
		private IFlurlRequest GetNotificationsUrl() => GetBaseUrl("/api/notifications");

		private IFlurlRequest GetNotificationsUrl(string path) => GetNotificationsUrl().AppendPathSegment(path);

		public async Task<bool> AddNotificationAsync(NotificationTypes type, string channel = null, string login = null, string project = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(type)] = NotificationTypesConverter.ToString(type),
				[nameof(channel)] = channel,
				[nameof(login)] = login,
				[nameof(project)] = project
			};

			var response = await GetNotificationsUrl("add")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}

		public async Task<NotificationsList> GetNotificationsListAsync(string login = null)
		{
			return await GetNotificationsUrl("list")
				.SetQueryParam(nameof(login), login)
				.GetJsonAsync<NotificationsList>()
				.ConfigureAwait(false);
		}

		public async Task<bool> RemoveNotificationAsync(NotificationTypes type, string channel = null, string login = null, string project = null)
		{
			var queryParamValues = new Dictionary<string, object>
			{
				[nameof(type)] = NotificationTypesConverter.ToString(type),
				[nameof(channel)] = channel,
				[nameof(login)] = login,
				[nameof(project)] = project
			};

			var response = await GetNotificationsUrl("remove")
				.SetQueryParams(queryParamValues)
				.PostAsync(s_emptyHttpContent)
				.ConfigureAwait(false);

			return await HandleResponseAsync(response).ConfigureAwait(false);
		}
	}
}
