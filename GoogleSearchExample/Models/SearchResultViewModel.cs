using GoogleSearchLibrary.Models;
using System;
using System.Collections.Generic;

namespace GoogleSearchExample.Models
{
    public class SearchResultViewModel
    {
        public IEnumerable<SearchResultItem> Results { get; set; }
        public double TimeElapsed { get; set; }
        public string SearchingText { get; set; }

        public static implicit operator SearchResultViewModel(SearchResult searchResult)
        {
            return new SearchResultViewModel
            {
                Results = searchResult.Items,
                TimeElapsed = Math.Round(searchResult.TimeElapsed, 2)
            };
        }
    }
}
