using GoogleSearchExample.Models;
using GoogleSearchLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GoogleSearchExample.Tests.Models
{
    public class SearchResultViewModelTests
    {
        [Fact(DisplayName = "Succesfull SearchResultViewModel mapping")]
        public void SuccesfullMapping()
        {
            var initialModel = new SearchResult()
            {
                Items = new List<SearchResultItem>() { new SearchResultItem() { Title = "test" } },
                TimeElapsed = 2
            };
            var convertedModel = (SearchResultViewModel)initialModel;

            Assert.True(convertedModel.Results.Any());
            Assert.Equal(1, convertedModel.Results.Count());
            Assert.Equal(2, convertedModel.TimeElapsed);
        }

        [Fact(DisplayName = "2 decimal places in SearchResultViewModel mapping")]
        public void ValidDecimalPlaces()
        {
            var initialModel = new SearchResult()
            {
                TimeElapsed = 2.1212
            };
            var convertedModel = (SearchResultViewModel)initialModel;

            Assert.Equal(2.12, convertedModel.TimeElapsed);
        }
    }
}
