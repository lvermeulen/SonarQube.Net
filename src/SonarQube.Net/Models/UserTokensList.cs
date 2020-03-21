using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class UserTokensList
	{
		public string Login { get; set; }
		public IEnumerable<UserToken> UserTokens { get; set; }
	}
}
