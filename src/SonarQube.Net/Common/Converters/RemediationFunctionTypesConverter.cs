using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class RemediationFunctionTypesConverter : JsonEnumConverter<RemediationFunctionTypes>
	{
		public static RemediationFunctionTypesConverter Instance { get; } = new RemediationFunctionTypesConverter();

		public static string ToString(RemediationFunctionTypes value) => Instance.ConvertToString(value);

		public static string ToString(RemediationFunctionTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<RemediationFunctionTypes, string> Map { get; } = new Dictionary<RemediationFunctionTypes, string>()
		{
			[RemediationFunctionTypes.Linear] = "LINEAR",
			[RemediationFunctionTypes.LinearOffset] = "LINEAR_OFFSET",
			[RemediationFunctionTypes.ConstantIssue] = "CONSTANT_ISSUE"
		};

		public override string Description { get; } = "remediation function type";
	}
}
