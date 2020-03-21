namespace SonarQube.Net.Models
{
	public class QualityProfileWithFamily : KeyedName
	{
		public string Parent { get; set; }
		public int? ActiveRuleCount { get; set; }
		public int? OverridingRuleCount { get; set; }
		public bool? IsBuiltIn { get; set; }
	}
}