using System.Collections.Generic;

namespace SonarQube.Net.Common.Models
{
	public class SonarQubeErrors
	{
		public IEnumerable<SonarQubeError> Errors { get; set; }
	}
}
