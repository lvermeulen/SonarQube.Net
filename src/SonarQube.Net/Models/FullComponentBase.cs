using System;

namespace SonarQube.Net.Models
{
	public abstract class FullComponentBase : ComponentBase
	{
		public string Path { get; set; }
		public DateTime? AnalysisDate { get; set; }
		public string Version { get; set; }
	}
}