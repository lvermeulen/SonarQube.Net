using System;

namespace SonarQube.Net.Models
{
	public class PluginRelease
	{
		public string Version { get; set; }
		public DateTime? Date { get; set; }
		public string Description { get; set; }
		public string ChangeLogUrl { get; set; }
	}
}