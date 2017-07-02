using System.Collections.Generic;
using GoogleSearchLibrary.Models;
using GoogleSearchLibrary.Configuration;
using System.Linq;
using System;
using GoogleSearchLibrary.Configuration.DI;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GoogleSearchLibrary.Tests")]
namespace GoogleSearchLibrary.Services
{
    public class SearchService : ISearchService
    {
        private IConfigurationProvider _configurationProvider;

        private IGoogleSearchAdapter _googleSearchAdapter;

        public SearchService() : this(
            ServiceLocator.Current.Get<IGoogleSearchAdapter>(),
            ServiceLocator.Current.Get<IConfigurationProvider>())
        {
        }

        internal SearchService(IGoogleSearchAdapter googleSearchAdapter, IConfigurationProvider configProvider)
        {
            _configurationProvider = configProvider;
            _googleSearchAdapter = googleSearchAdapter;
        }

        public SearchResult GetResults(string searchText, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var startTime = DateTime.Now.TimeOfDay;
                var result = new SearchResult()
                {
                    Items = _googleSearchAdapter.GetSearchResults(searchText, page, pageSize)
                    .Take(pageSize)
                    .Select(p => new SearchResultItem()
                    {
                        Link = p.Link,
                        Title = p.Title,
                        Snippet = p.Snippet
                    }),

                    TimeElapsed = (DateTime.Now.TimeOfDay - startTime).TotalSeconds
                };

                return result;
            }

            return new SearchResult() { Items = new List<SearchResultItem>() };
        }
    }
}
