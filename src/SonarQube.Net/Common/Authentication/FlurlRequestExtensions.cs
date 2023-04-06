using System;
using Flurl;
using Flurl.Http;

namespace SonarQube.Net.Common.Authentication
{
	public static class FlurlRequestExtensions
	{
		public static IFlurlRequest WithAuthentication(this IFlurlRequest request, AuthenticationMethod auth)
		{
			switch (auth)
			{
				case BasicAuthentication basic:
					return request.WithBasicAuth(basic.UserName, basic.Password);
				case BearerAuthentication bearer:
					return request.WithHeader("Authorization", $"Bearer {bearer.Token}");
				default:
					throw new InvalidOperationException("Unknown authentication method");
			}
		}
	}
}
