using System;
using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class SystemUpgrades
	{
		public IEnumerable<SystemUpgrade> Upgrades { get; set; }
		public DateTime? UpdateCenterRefresh { get; set; }
	}
}
