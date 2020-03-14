namespace SonarQube.Net.Models
{
	public class DuplicationBlock
	{
		public int From { get; set; }
		public int Size { get; set; }
		public string Ref { get; set; }
	}
}