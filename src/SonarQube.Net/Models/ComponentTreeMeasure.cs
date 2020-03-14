using System.Collections.Generic;
using SonarQube.Net.Common.Models;

namespace SonarQube.Net.Models
{
	public class ComponentTreeMeasure
	{
		public Paging Paging { get; set; }
		public BaseMeasureComponent BaseComponent { get; set; }
		public IEnumerable<MeasureComponent> Components { get; set; }
		public IEnumerable<FullMetric> Metrics { get; set; }
		public HasValue Period { get; set; }
	}
}
