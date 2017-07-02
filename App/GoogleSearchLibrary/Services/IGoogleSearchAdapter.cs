using Google.Apis.Customsearch.v1.Data;
using System.Collections.Generic;

namespace GoogleSearchLibrary.Services
{
    public interface IGoogleSearchAdapter
    {
        IList<Result> GetSearchResults(string text, int page, int pageSize);
    }
}
