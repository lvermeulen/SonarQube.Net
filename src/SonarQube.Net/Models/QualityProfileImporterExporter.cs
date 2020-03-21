using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class QualityProfileImporterExporter : KeyedName
	{
		public IEnumerable<string> Languages { get; set; }
	}
}
