using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class PendingPlugins
	{
		public IEnumerable<MovingPlugin> Installing { get; set; }
		public IEnumerable<MovingPlugin> Updating { get; set; }
		public IEnumerable<MovingPlugin> Removing { get; set; }
	}
}
