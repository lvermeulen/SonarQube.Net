namespace SonarQube.Net.Models
{
	public abstract class QualityProfileBase : KeyedName
	{
		public string Language { get; set; }
		public bool? IsDefault { get; set; }
		public bool? IsInherited { get; set; }
	}
}