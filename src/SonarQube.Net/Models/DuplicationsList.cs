using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class DuplicationsList
	{
		public IEnumerable<Duplication> Duplications { get; set; }
		public IDictionary<string, DuplicationFile> Files { get; set; }
	}
}
