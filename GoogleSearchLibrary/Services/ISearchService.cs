using GoogleSearchLibrary.Models;
using System.Collections.Generic;

namespace GoogleSearchLibrary.Services
{
    public interface ISearchService
    {
        IEnumerable<SearchResult> GetResults(string searchText);
    }
}
