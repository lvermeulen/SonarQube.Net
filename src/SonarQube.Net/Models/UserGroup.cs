namespace SonarQube.Net.Models
{
	public class UserGroup
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Selected { get; set; }
		public bool Default { get; set; }
	}
}
