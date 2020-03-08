using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class NewCodePeriodTypeConverter : JsonEnumConverter<NewCodePeriodTypes>
	{
		public override Dictionary<NewCodePeriodTypes, string> Map { get; } = new Dictionary<NewCodePeriodTypes, string>
		{
			[NewCodePeriodTypes.SpecificAnalysis] = "SPECIFIC_ANALYSIS",
			[NewCodePeriodTypes.PreviousVersion] = "PREVIOUS_VERSION",
			[NewCodePeriodTypes.NumberOfDays] = "NUMBER_OF_DAYS",
		};

		public override string Description { get; } = "new code period type";
	}
}
