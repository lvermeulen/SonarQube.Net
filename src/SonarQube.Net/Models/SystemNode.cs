using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class SystemNode
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Host { get; set; }
		public int? Port { get; set; }
		public DateTime? StartedAt { get; set; }

		[JsonConverter(typeof(HealthTypesConverter))]
		public HealthTypes Health { get; set; }

		public IEnumerable<HasMessage> Causes { get; set; }
	}
}