namespace SonarQube.Net.Models
{
	public class UserRef
	{
		public string Login { get; set; }
		public string Name { get; set; }
		public bool? Active { get; set; }
		public string Avatar { get; set; }
	}
}