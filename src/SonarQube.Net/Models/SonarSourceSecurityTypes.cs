namespace SonarQube.Net.Models
{
	public enum SonarSourceSecurityTypes
	{
		SqlInjection,
		CommandInjection,
		PathTraversalInjection,
		LdapInjection,
		XpathInjection,
		Rce,
		Dos,
		Ssrf,
		Csrf,
		Xss,
		LogInjection,
		HttpResponseSplitting,
		OpenRedirect,
		Xxe,
		ObjectInjection,
		WeakCryptography,
		Auth,
		InsecureConf,
		FileManipulation,
		Others
	}
}
