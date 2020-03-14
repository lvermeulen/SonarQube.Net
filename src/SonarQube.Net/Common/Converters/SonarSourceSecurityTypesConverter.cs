using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class SonarSourceSecurityTypesConverter : JsonEnumConverter<SonarSourceSecurityTypes>
	{
		public static SonarSourceSecurityTypesConverter Instance { get; } = new SonarSourceSecurityTypesConverter();

		public static string ToString(SonarSourceSecurityTypes value) => Instance.ConvertToString(value);

		public override Dictionary<SonarSourceSecurityTypes, string> Map { get; } = new Dictionary<SonarSourceSecurityTypes, string>
		{
			[SonarSourceSecurityTypes.SqlInjection] = "sql-injection",
			[SonarSourceSecurityTypes.CommandInjection] = "command-injection",
			[SonarSourceSecurityTypes.PathTraversalInjection] = "path-traversal-injection",
			[SonarSourceSecurityTypes.LdapInjection] = "ldap-injection",
			[SonarSourceSecurityTypes.XpathInjection] = "xpath-injection",
			[SonarSourceSecurityTypes.Rce] = "rce",
			[SonarSourceSecurityTypes.Dos] = "dos",
			[SonarSourceSecurityTypes.Ssrf] = "ssrf",
			[SonarSourceSecurityTypes.Csrf] = "csrf",
			[SonarSourceSecurityTypes.Xss] = "xss",
			[SonarSourceSecurityTypes.LogInjection] = "log-injection",
			[SonarSourceSecurityTypes.HttpResponseSplitting] = "http-response-splitting",
			[SonarSourceSecurityTypes.OpenRedirect] = "open-redirect",
			[SonarSourceSecurityTypes.Xxe] = "xxe",
			[SonarSourceSecurityTypes.ObjectInjection] = "object-injection",
			[SonarSourceSecurityTypes.WeakCryptography] = "weak-cryptography",
			[SonarSourceSecurityTypes.Auth] = "auth",
			[SonarSourceSecurityTypes.InsecureConf] = "insecure-conf",
			[SonarSourceSecurityTypes.FileManipulation] = "file-manipulation",
			[SonarSourceSecurityTypes.Others] = "others"
		};

		public override string Description { get; } = "SonarSource security type";
	}
}
