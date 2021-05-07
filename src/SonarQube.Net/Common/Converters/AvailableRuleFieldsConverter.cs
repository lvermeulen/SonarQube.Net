using System.Collections.Generic;
using SonarQube.Net.Models;

namespace SonarQube.Net.Common.Converters
{
	public class AvailableRuleFieldsConverter : JsonEnumConverter<AvailableRuleFields>
	{
		public static AvailableRuleFieldsConverter Instance { get; } = new AvailableRuleFieldsConverter();

		public static string ToString(AvailableRuleFields value) => Instance.ConvertToString(value);

		public static string ToString(AvailableRuleFields? value) => value.HasValue
			? ToString(value.Value)
			: null;

		public override Dictionary<AvailableRuleFields, string> Map { get; } = new Dictionary<AvailableRuleFields, string>
		{
			[AvailableRuleFields.Actives] = "actives",
			[AvailableRuleFields.CreatedAt] = "createdAt",
			[AvailableRuleFields.DebtOverloaded] = "debtOverloaded",
			[AvailableRuleFields.DebtRemFn] = "debtRemFn",
			[AvailableRuleFields.DefaultDebtRemFn] = "defaultDebtRemFn",
			[AvailableRuleFields.DefaultRemFn] = "defaultRemFn",
			[AvailableRuleFields.EffortToFixDescription] = "effortToFixDescription",
			[AvailableRuleFields.GapDescription] = "gapDescription",
			[AvailableRuleFields.HtmlDesc] = "htmlDesc",
			[AvailableRuleFields.HtmlNote] = "htmlNote",
			[AvailableRuleFields.InternalKey] = "internalKey",
			[AvailableRuleFields.IsExternal] = "isExternal",
			[AvailableRuleFields.IsTemplate] = "isTemplate",
			[AvailableRuleFields.Lang] = "lang",
			[AvailableRuleFields.LangName] = "langName",
			[AvailableRuleFields.MdDesc] = "mdDesc",
			[AvailableRuleFields.MdNote] = "mdNote",
			[AvailableRuleFields.Name] = "name",
			[AvailableRuleFields.NoteLogin] = "noteLogin",
			[AvailableRuleFields.Params] = "params",
			[AvailableRuleFields.RemFn] = "remFn",
			[AvailableRuleFields.RemFnOverloaded] = "remFnOverloaded",
			[AvailableRuleFields.Repo] = "repo",
			[AvailableRuleFields.Scope] = "scope",
			[AvailableRuleFields.Severity] = "severity",
			[AvailableRuleFields.Status] = "status",
			[AvailableRuleFields.SysTags] = "sysTags",
			[AvailableRuleFields.Tags] = "tags",
			[AvailableRuleFields.TemplateKey] = "templateKey",
			[AvailableRuleFields.UpdatedAt] = "updatedAt"
		};

		public override string Description => "available rule field";
	}
}
