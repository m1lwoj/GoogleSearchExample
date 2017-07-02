using Google.Apis.Customsearch.v1.Data;
using GoogleSearchLibrary.Configuration;
using GoogleSearchLibrary.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GoogleSearchLibraryTests.Services
{
    public class SearchServiceTests
    {
        [Fact(DisplayName = "Searching custom text in Google", Skip = "Integration test")]
        public void ResultsForCustomPhrase()
        {
            var searchService = new SearchService();
            var result = searchService.GetResults("Pizzeria cracow", 1, 10);
            var count = result.Items.Count();
        }

        [Fact()]
        public void EmptyResultsForEmptyText()
        {
            var searchService = new SearchService();
            var result = searchService.GetResults(string.Empty, 1, 10);
            Assert.False(result.Items.Any());
        }

        [Fact()]
        public void ResultsEqualsToPageSize()
        {
            var configProviderMock = Mock.Of<IConfigurationProvider>();
            Mock.Get(configProviderMock).Setup(s => s.GetConfiguration()).Returns(new ConfigurationModel());
            var searchAdapterMock = Mock.Of<IGoogleSearchAdapter>();
            Mock.Get(searchAdapterMock).Setup(s => s.GetSearchResults(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Result>() {
                    new Result(),
                    new Result(),
                    new Result(),
                    new Result()
                });

            var searchService = new SearchService(searchAdapterMock, configProviderMock);
            var result = searchService.GetResults("custom text", 1, 3);
            Assert.True(result.Items.Any());
            Assert.Equal(3, result.Items.Count());
        }
    }
}
