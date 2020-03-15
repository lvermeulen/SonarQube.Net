using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class UpgradePlugins
	{
		public IEnumerable<RequireUpdatePlugin> RequireUpdate { get; set; }
		public IEnumerable<IncompatiblePlugin> Incompatible { get; set; }
	}
}