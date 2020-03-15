using System;
using Newtonsoft.Json;
using SonarQube.Net.Common.Converters;

namespace SonarQube.Net.Models
{
	public class DbMigrationState
	{
		[JsonConverter(typeof(DbMigrationStatusesConverter))]
		public DbMigrationStatuses State { get; set; }

		public string Message { get; set; }
		public DateTime? StartedAt { get; set; }
	}
}
