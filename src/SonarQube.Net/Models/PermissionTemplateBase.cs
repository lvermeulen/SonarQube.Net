using System;

namespace SonarQube.Net.Models
{
	public abstract class PermissionTemplateBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}