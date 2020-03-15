using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class WebService
	{
		public string Path { get; set; }
		public string Since { get; set; }
		public string Description { get; set; }
		public IEnumerable<WebServiceAction> Actions { get; set; }
	}
}
