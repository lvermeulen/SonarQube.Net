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
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.Build();

			_client = new SonarQubeClient(configuration["url"], new BasicAuthentication(configuration["userName"], configuration["password"]));
		}
	}
}
