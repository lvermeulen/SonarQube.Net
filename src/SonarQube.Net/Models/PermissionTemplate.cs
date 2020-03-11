using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class PermissionTemplate : PermissionTemplateBase
	{
		public IEnumerable<Permission> Permissions { get; set; }
	}
}