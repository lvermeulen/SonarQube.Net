using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class UpdatedPlugin : AvailablePlugin
	{
		public IEnumerable<PluginUpdate> Updates { get; set; }
	}
}
