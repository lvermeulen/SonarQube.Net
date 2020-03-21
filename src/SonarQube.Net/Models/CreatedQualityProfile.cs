using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class CreatedQualityProfile
	{
		public QualityProfile Profile { get; set; }
		public IEnumerable<string> Warnings { get; set; }
	}
}