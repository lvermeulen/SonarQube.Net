using SonarQube.Net.Common;
using Xunit;

namespace SonarQube.Net.Tests.Common
{
	public class FlurlRequestExtensionsShould
	{
		[Fact]
		public void GetJsonFirstNode()
		{
			const string json = @"{
  ""languages"": [
		{""key"": ""c"", ""name"": ""C""}
	]
}";

			var tokens = json.GetJsonTokens();
			var jproperty = tokens.GetJsonPropertyByIndex(0);
			Assert.NotNull(jproperty);
		}

		[Fact]
		public void GetJsonNamedNode()
		{
			const string json = @"{
  ""paging"": {
	""pageIndex"": 1,
	""pageSize"": 100,
	""total"": 2
  },
  ""components"": [
	{
	  ""organization"": ""my-org-1"",
	  ""key"": ""project-key-1"",
	  ""name"": ""Project Name 1"",
	  ""qualifier"": ""TRK"",
	  ""visibility"": ""public"",
	  ""lastAnalysisDate"": ""2017-03-01T11:39:03+0300"",
	  ""revision"": ""cfb82f55c6ef32e61828c4cb3db2da12795fd767""
	},
	{
	  ""organization"": ""my-org-1"",
	  ""key"": ""project-key-2"",
	  ""name"": ""Project Name 1"",
	  ""qualifier"": ""TRK"",
	  ""visibility"": ""private"",
	  ""lastAnalysisDate"": ""2017-03-02T15:21:47+0300"",
	  ""revision"": ""7be96a94ac0c95a61ee6ee0ef9c6f808d386a355""
	}
  ]
}
";

			var tokens = json.GetJsonTokens();
			var jproperty = tokens.GetJsonPropertyByName("components");
			Assert.NotNull(jproperty);
		}
	}
}
