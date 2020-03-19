namespace SonarQube.Net.Models
{
	public class SelectedQualityGate : KeyedName
	{
		public int Id { get; set; }
		public bool Selected { get; set; }
	}

}
