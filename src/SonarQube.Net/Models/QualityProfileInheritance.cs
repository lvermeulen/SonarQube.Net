using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityProfileInheritance
	{
		public QualityProfileWithFamily Profile { get; set; }
		public IEnumerable<QualityProfileWithFamily> Ancestors { get; set; }
		public IEnumerable<QualityProfileWithFamily> Children { get; set; }
	}
}
