using System;

namespace SonarQube.Net.Models
{
	public class FullComponent : FullComponentBase
	{
		public string Language { get; set; }
		public DateTime? LeakPeriodDate { get; set; }
	}
}