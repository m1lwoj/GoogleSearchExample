using GoogleSearchLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleSearchLibraryTests.Services
{
    public class PagingConverterTests
    {
        [Theory(DisplayName = "Coneverting page and pagesize to Google range")]
        [InlineData(1, 12, 1, 20)]
        [InlineData(2, 12, 11, 30)]
        [InlineData(3, 25, 51, 80)]
        [InlineData(4, 5, 11, 20)]
        [InlineData(4, 62, 181, 250)]
        public void StartingPointCalculation(int page, int pageSize, int epectedStartPoint, int expectedEndPoint)
        {
            var startingPoint = GoogleSearchPagingConverter.GetStartingPoint(page, pageSize);
            var endingPoint = GoogleSearchPagingConverter.GetEndingPoint(page, pageSize);
            Assert.Equal(epectedStartPoint, startingPoint);
            Assert.Equal(expectedEndPoint, endingPoint);
        }
    }
}
