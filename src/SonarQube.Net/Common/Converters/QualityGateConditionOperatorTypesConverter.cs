using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class QualityGateConditionOperatorTypesConverter : JsonEnumConverter<QualityGateConditionOperatorTypes>
	{
		public static QualityGateConditionOperatorTypesConverter Instance { get; } = new QualityGateConditionOperatorTypesConverter();

		public static string ToString(QualityGateConditionOperatorTypes value) => Instance.ConvertToString(value);

		public static string ToString(QualityGateConditionOperatorTypes? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<QualityGateConditionOperatorTypes, string> Map { get; } = new Dictionary<QualityGateConditionOperatorTypes, string>
		{
			[QualityGateConditionOperatorTypes.LessThan] = "LT",
			[QualityGateConditionOperatorTypes.GreaterThan] = "GT"
		};

		public override string Description => "quality gate condition operator type";
	}
}
