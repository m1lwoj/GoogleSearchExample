using GoogleSearchExample.Controllers;
using GoogleSearchLibrary.Services;
using System.Collections.Generic;
using Xunit;
using Moq;
using GoogleSearchLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleSearchExample.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact()]
        public void Search()
        {
            var searchServiceMock = Mock.Of<ISearchService>();
            Mock.Get(searchServiceMock).Setup(s => s.GetResults(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new SearchResult()
                {
                    Items = new List<SearchResultItem>() { new SearchResultItem() },
                    TimeElapsed = 2
                });

            var controller = new HomeController(searchServiceMock);
            var result = controller.Index("test");

            Assert.IsType(typeof(ViewResult), result);
        }
    }
}