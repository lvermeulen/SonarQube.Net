using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class FullComponentWithAncestors
	{
		public FullComponent Component { get; set; }
		public IEnumerable<ComponentAncestor> Ancestors { get; set; }
	}
}
