using GoogleSearchLibrary.Models;

namespace GoogleSearchLibrary.Services
{
    public interface ISearchService
    {
        SearchResult GetResults(string searchText, int page, int pageSize);
    }
}
