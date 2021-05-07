namespace SonarQube.Net.Models
{
	public abstract class UserGroupBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? Default { get; set; }
	}
}
