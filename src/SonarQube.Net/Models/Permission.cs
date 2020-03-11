namespace SonarQube.Net.Models
{
	public class Permission
	{
		public string Key { get; set; }
		public int UsersCount { get; set; }
		public int GroupsCount { get; set; }
		public bool WithProjectCreator { get; set; }
	}
}