namespace SonarQube.Net.Models
{
	public class InstalledPlugin : MovingPlugin
	{
		public bool? EditionBundled { get; set; }
		public string Filename { get; set; }
		public string Hash { get; set; }
		public bool? SonarLintSupported { get; set; }
		public long? UpdatedAt { get; set; }
	}
}
