using GoogleSearchLibrary.Services;
using System.Linq;
using Xunit;

namespace GoogleSearchLibraryTests.Services
{
    public class SearchServiceTests
    {
        [Fact(DisplayName = "Searching custom text in Google", Skip = "Integration test")]
        public void JsonConfigurationReader()
        {
            var searchService = new SearchService();
            var result = searchService.GetResults("Pizzeria cracow");
            var count = result.Count();
        }
    }
}
