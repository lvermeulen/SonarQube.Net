using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class FacetsConverter : JsonEnumConverter<Facets>
	{
		public static FacetsConverter Instance { get; } = new FacetsConverter();

		public static string ToString(Facets value) => Instance.ConvertToString(value);

		public override Dictionary<Facets, string> Map { get; } = new Dictionary<Facets, string>
		{
			[Facets.Projects] = "projects",
			[Facets.ModuleUuids] = "moduleUuids",
			[Facets.FileUuids] = "fileUuids",
			[Facets.AssignedToMe] = "assigned_to_me",
			[Facets.Severities] = "severities",
			[Facets.Statuses] = "statuses",
			[Facets.Resolutions] = "resolutions",
			[Facets.Rules] = "rules",
			[Facets.Assignees] = "assignees",
			[Facets.Authors] = "authors",
			[Facets.Author] = "author",
			[Facets.Directories] = "directories",
			[Facets.Languages] = "languages",
			[Facets.Tags] = "tags",
			[Facets.Types] = "types",
			[Facets.OwaspTop10] = "owaspTop10",
			[Facets.SansTop25] = "sansTop25",
			[Facets.Cwe] = "cwe",
			[Facets.CreatedAt] = "createdAt",
			[Facets.SonarsourceSecurity] = "sonarsourceSecurity",
			[Facets.Repositories] = "repositories",
			[Facets.ActiveSeverities] = "active_severities",
			[Facets.True] = "true"
		};

		public override string Description => "issue facet";
	}
}
