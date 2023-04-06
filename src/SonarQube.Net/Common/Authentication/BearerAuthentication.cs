namespace SonarQube.Net.Common.Authentication
{
	public class BearerAuthentication : AuthenticationMethod
	{
		public string Token { get; }

		public BearerAuthentication(string token)
		{
			Token = token;
		}
	}
}
