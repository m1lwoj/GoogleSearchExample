using GoogleSearchLibrary.Configuration;
using Xunit;

namespace GoogleSearchLibraryTests.Configuration
{
    public class ConfigurationProviderTests
    {
        [Fact(DisplayName = "Reading config from JSON", Skip = "Integration test")]
        public void JsonConfigurationReader()
        {
            var configProvider = new JsonConfigurationProvider();
            var result = configProvider.GetConfiguration();

            Assert.True(!string.IsNullOrEmpty(result.ApiKey));
            Assert.True(!string.IsNullOrEmpty(result.EngineId));
            Assert.NotEqual(0, result.ResultsOnPage);
        }
    }
}
