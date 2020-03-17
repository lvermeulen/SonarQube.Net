namespace SonarQube.Net.Models
{
	public class ProjectAnalysisEvent : KeyedName
	{
		public string Analysis { get; set; }
		public EventCategories Category { get; set; }
	}
}
