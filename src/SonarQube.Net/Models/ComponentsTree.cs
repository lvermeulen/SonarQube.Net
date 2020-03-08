using System.Collections.Generic;
using SonarQube.Net.Common.Models;

namespace SonarQube.Net.Models
{
	public class ComponentsTree
	{
		public Paging Paging { get; set; }
		public ComponentAncestor BaseComponent { get; set; }
		public IEnumerable<FullComponent> Components { get; set; }
	}
}
