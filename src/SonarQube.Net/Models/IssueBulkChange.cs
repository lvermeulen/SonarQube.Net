namespace SonarQube.Net.Models
{
	public class IssueBulkChange
	{
		public int? Total { get; set; }
		public int? Success { get; set; }
		public int? Ignored { get; set; }
		public int? Failures { get; set; }
	}
}
