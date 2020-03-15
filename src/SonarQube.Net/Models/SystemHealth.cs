using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class SystemHealth
	{
		[JsonConverter(typeof(HealthTypesConverter))]
		public HealthTypes Health { get; set; }

		public IEnumerable<HasMessage> Causes { get; set; }
		public IEnumerable<SystemNode> Nodes { get; set; }
	}
}
