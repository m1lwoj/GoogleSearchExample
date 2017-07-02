using Microsoft.AspNetCore.Mvc;
using GoogleSearchExample.Models;
using GoogleSearchLibrary.Services;
using GoogleSearchLibrary.Models;
using System.Collections.Generic;

namespace GoogleSearchExample.Controllers
{
    public class HomeController : Controller
    {
        private static byte PageSize = 12;
        private static byte Page = 1;

        private ISearchService _searchService;

        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index(string searchText)
        {
            var result = (SearchResultViewModel)_searchService.GetResults(searchText, Page, PageSize);
            result.SearchingText = searchText;

            return View(result);
        }
    }
}
