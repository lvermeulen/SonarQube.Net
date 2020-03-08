namespace SonarQube.Net.Models
{
	public class CeActivityStatus
	{
		public int Pending { get; set; }
		public int InProgress { get; set; }
		public int Failing { get; set; }
		public int PendingTime { get; set; }
	}
}
