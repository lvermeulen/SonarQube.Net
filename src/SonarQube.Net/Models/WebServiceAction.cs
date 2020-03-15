using System.Collections.Generic;

namespace SonarQube.Net.Models
{
	public class WebServiceAction
	{
		public string Key { get; set; }
		public string Description { get; set; }
		public string Since { get; set; }
		public string DeprecatedSince { get; set; }
		public bool Internal { get; set; }
		public bool Post { get; set; }
		public bool HasResponseExample { get; set; }
		public IEnumerable<WebServiceChangeLog> Changelog { get; set; }
		public IEnumerable<WebServiceParameter> Params { get; set; }
	}
}