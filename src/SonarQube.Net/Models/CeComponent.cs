using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class CeComponent
	{
		public IEnumerable<QueuedCeComponent> Queue { get; set; }
		public CurrentCeComponent Current { get; set; }
	}
}
