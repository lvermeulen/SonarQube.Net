using System.Collections.Generic;
using SonarQube.Net.Common.Models;

namespace SonarQube.Net.Models
{
	public class MeasuresHistory
	{
		public Paging Paging { get; set; }
		public IEnumerable<MeasureHistoryItem> Measures { get; set; }
	}
}
