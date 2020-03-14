using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class IssueFacetsConverter : JsonEnumConverter<IssueFacets>
	{
		public static IssueFacetsConverter Instance { get; } = new IssueFacetsConverter();

		public static string ToString(IssueFacets value) => Instance.ConvertToString(value);

		public override Dictionary<IssueFacets, string> Map { get; } = new Dictionary<IssueFacets, string>
		{
			[IssueFacets.Projects] = "projects",
			[IssueFacets.ModuleUuids] = "moduleUuids",
			[IssueFacets.FileUuids] = "fileUuids",
			[IssueFacets.AssignedToMe] = "assigned_to_me",
			[IssueFacets.Severities] = "severities",
			[IssueFacets.Statuses] = "statuses",
			[IssueFacets.Resolutions] = "resolutions",
			[IssueFacets.Rules] = "rules",
			[IssueFacets.Assignees] = "assignees",
			[IssueFacets.Authors] = "authors",
			[IssueFacets.Author] = "author",
			[IssueFacets.Directories] = "directories",
			[IssueFacets.Languages] = "languages",
			[IssueFacets.Tags] = "tags",
			[IssueFacets.Types] = "types",
			[IssueFacets.OwaspTop10] = "owaspTop10",
			[IssueFacets.SansTop25] = "sansTop25",
			[IssueFacets.Cwe] = "cwe",
			[IssueFacets.CreatedAt] = "createdAt",
			[IssueFacets.SonarsourceSecurity] = "sonarsourceSecurity"
		};

		public override string Description { get; } = "issue facet";
	}
}
