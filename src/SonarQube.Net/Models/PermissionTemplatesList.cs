using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class PermissionTemplatesList
	{
		public IEnumerable<PermissionTemplate> PermissionTemplates { get; set; }
		public IEnumerable<DefaultPermissionTemplate> DefaultTemplates { get; set; }
		public IEnumerable<PermissionReference> Permissions { get; set; }
	}
}
