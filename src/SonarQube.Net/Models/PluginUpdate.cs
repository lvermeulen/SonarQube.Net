using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class PluginUpdate
	{
		public PluginRelease Release { get; set; }

		[JsonConverter(typeof(PluginStatusesConverter))]
		public PluginStatuses Status { get; set; }

		public IEnumerable<PluginUpdateRequirement> Requires { get; set; }
	}
}