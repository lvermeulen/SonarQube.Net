using System;
using Flurl.Http;

namespace SonarQube.Net.Common.Authentication
{
	public static class FlurlRequestExtensions
	{
		public static IFlurlRequest WithAuthentication(this IFlurlRequest request, AuthenticationMethod auth)
		{
			if (auth.GetType() == typeof(BasicAuthentication))
			{
				var basic = (BasicAuthentication)auth;
				return request.WithBasicAuth(basic.UserName, basic.Password);
			}

			throw new InvalidOperationException("Unknown authentication method");
		}
	}
}
