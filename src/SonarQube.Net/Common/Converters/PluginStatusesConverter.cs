using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class PluginStatusesConverter : JsonEnumConverter<PluginStatuses>
	{
		protected override Dictionary<PluginStatuses, string> Map { get; } = new Dictionary<PluginStatuses, string>
		{
			[PluginStatuses.Compatible] = "COMPATIBLE",
			[PluginStatuses.Incompatible] = "INCOMPATIBLE",
			[PluginStatuses.RequiresSystemUpgrade] = "REQUIRES_SYSTEM_UPGRADE",
			[PluginStatuses.DepsRequireSystemUpgrade] = "DEPS_REQUIRE_SYSTEM_UPGRADE"
		};

		protected override string Description { get; } = "plugin status";
	}
}
