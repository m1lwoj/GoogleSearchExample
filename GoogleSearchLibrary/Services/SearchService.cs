using System;
using System.Collections.Generic;
using GoogleSearchLibrary.Models;
using GoogleSearchLibrary.Configuration;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Google.Apis.Customsearch.v1.Data;

namespace GoogleSearchLibrary.Services
{
    public class SearchService : ISearchService
    {
        private static byte GooglePageSize = 10;

        public IConfigurationProvider ConfigurationProvider
        {
            get
            {
                return new JsonConfigurationProvider();
            }
        }

        public IEnumerable<SearchResult> GetResults(string searchText)
        {
            var results = new List<SearchResult>();
            var config = ConfigurationProvider.GetConfiguration();
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = config.ApiKey });
            var listRequest = customSearchService.Cse.List(searchText);
            listRequest.Cx = config.EngineId;

            IList<Result> paging = new List<Result>();
            var page = 0;
            var loadedResults = 0;
            while (paging != null)
            {
                Console.WriteLine($"Page {page}");
                long startPoint = page * GooglePageSize + 1;
                if(startPoint >= config.MaxResults)
                {
                    break;
                }

                listRequest.Start = startPoint;
                paging = listRequest.Execute().Items;
                if (paging != null)
                {
                    foreach (var item in paging)
                    {
                        results.Add(new SearchResult() { Link = item.Link, Title = item.Title });
                        loadedResults++;
                    }
                    page++;
                }
            }
            Console.WriteLine("Done.");

            return results;
        }
    }
}
