namespace SonarQube.Net.Models
{
	public class TextRange
	{
		public int StartLine { get; set; }
		public int EndLine { get; set; }
		public int StartOffset { get; set; }
		public int EndOffset { get; set; }
	}
}