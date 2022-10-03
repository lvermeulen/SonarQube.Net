﻿using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class AvailableMeasureFieldsConverter : JsonEnumConverter<AvailableMeasureFields>
	{
		public static AvailableMeasureFieldsConverter Instance { get; } = new AvailableMeasureFieldsConverter();

		public static string ToString(AvailableMeasureFields value) => Instance.ConvertToString(value);

		public override Dictionary<AvailableMeasureFields, string> Map { get; } = new Dictionary<AvailableMeasureFields, string>
		{
			[AvailableMeasureFields.Metrics] = "metrics",
			[AvailableMeasureFields.Period] = "period",
			[AvailableMeasureFields.Periods] = "periods"
		};

		public override string Description => "available measure field";
	}
}
