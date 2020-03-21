using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class UserGroupFieldsConverter : StringConverter<UserGroupFields>
	{
		public static UserGroupFieldsConverter Instance { get; } = new UserGroupFieldsConverter();

		public static string ToString(UserGroupFields value) => Instance.ConvertToString(value);

		public static string ToString(UserGroupFields? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<UserGroupFields, string> Map { get; } = new Dictionary<UserGroupFields, string>
		{
			[UserGroupFields.Name] = "name",
			[UserGroupFields.Description] = "description",
			[UserGroupFields.MembersCount] = "membersCount"
		};

		public override string Description { get; } = "user group field";
	}
}
