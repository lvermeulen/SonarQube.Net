using System.IO;
using Microsoft.Extensions.Configuration;
using SonarQube.Net.Common.Authentication;

namespace SonarQube.Net.Tests
{
	public partial class SonarQubeClientShould
	{
		private readonly SonarQubeClient _client;

		public SonarQubeClientShould()
		{
            var configurationUrl = $"http://localhost/{nameof(SonarQube)}.{nameof(SonarQube.Net)}.{nameof(SonarQube.Net.Tests)}";
            var userName = "Hopefully uing a PAT";
            var password = string.Empty;
			_client = new SonarQubeClient(configurationUrl, new BasicAuthentication(userName, password));
		}
	}
}
