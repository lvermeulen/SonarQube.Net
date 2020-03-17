using System;
using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class ProjectAnalysis
	{
		public string Key { get; set; }
		public DateTime? Date { get; set; }
		public string ProjectVersion { get; set; }
		public string BuildString { get; set; }
		public string Revision { get; set; }
		public bool ManualNewCodePeriodBaseline { get; set; }
		public IEnumerable<Event> Events { get; set; }
	}
}
