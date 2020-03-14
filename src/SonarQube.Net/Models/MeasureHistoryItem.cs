using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class MeasureHistoryItem
	{
		public string Metric { get; set; }
		public IEnumerable<HistoryItem> History { get; set; }
	}
}