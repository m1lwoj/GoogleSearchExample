using System.Collections.Generic;

namespace GoogleSearchLibrary.Models
{
    public class SearchResult
    {
        public IEnumerable<SearchResultItem> Items { get; set; }
        public double TimeElapsed { get; set; }
    }
}
