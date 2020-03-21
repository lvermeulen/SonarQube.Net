using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class User : UserRef
	{
		public string Email { get; set; }
		public IEnumerable<string> Groups { get; set; }
		public int? TokensCount { get; set; }
		public bool? Local { get; set; }
		public string ExternalIdentity { get; set; }
		public string ExternalProvider { get; set; }
		public IEnumerable<string> ScmAccounts { get; set; }
	}
}
