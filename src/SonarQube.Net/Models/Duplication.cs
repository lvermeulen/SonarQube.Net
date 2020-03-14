using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class Duplication
	{
		public IEnumerable<DuplicationBlock> Blocks { get; set; }
	}
}