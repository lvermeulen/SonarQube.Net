using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class ComponentMeasure
	{
		public MeasureComponent Component { get; set; }
		public IEnumerable<FullMetric> Metrics { get; set; }
		public MeasurePeriod Period { get; set; }
	}
}
