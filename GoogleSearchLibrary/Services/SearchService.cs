using System.Collections.Generic;
using GoogleSearchLibrary.Models;
using GoogleSearchLibrary.Configuration;
using System.Linq;

namespace GoogleSearchLibrary.Services
{
    public class SearchService : ISearchService
    {
        private static byte GooglePageSize = 10;

        private ConfigurationModel _config => _configurationProvider.GetConfiguration();

        private IConfigurationProvider _configurationProvider;

        private IGoogleSearchProcess _googleSearchProcess;

        public SearchService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = new JsonConfigurationProvider();
            _googleSearchProcess = new GoogleSearchProcess(_config);
        }

        public IEnumerable<SearchResult> GetResults(string searchText)
        {
            _googleSearchProcess.SetUp(searchText, _config.MaxResults);
            var results = new List<SearchResult>();

            while (_googleSearchProcess.HasMoreResults)
            {
                long startPoint = _googleSearchProcess.CurrentPage * GooglePageSize + 1;

                results.AddRange(_googleSearchProcess.GetResults(startPoint)
                    .Select(p => new SearchResult()
                    {
                        Link = p.Link,
                        Title = p.Title
                    }));
            }

            _googleSearchProcess.Finish();

            return results;
        }
    }
}
