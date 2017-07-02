using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using GoogleSearchLibrary.Configuration;
using System.Collections.Generic;

namespace GoogleSearchLibrary.Services
{
    internal class GoogleSearchAdapter : IGoogleSearchAdapter
    {
        private ConfigurationModel _config;

        public GoogleSearchAdapter(IConfigurationProvider configProvider)
        {
            _config = configProvider.GetConfiguration();
        }

        public IList<Result> GetSearchResults(string text, int page, int pageSize)
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = _config.ApiKey });
            var listRequest = customSearchService.Cse.List(text);
            listRequest.Cx = _config.EngineId;
            var startingPoint = GoogleSearchPagingConverter.GetStartingPoint(page, pageSize);
            var endingPoint = GoogleSearchPagingConverter.GetEndingPoint(page, pageSize);
            var results = new List<Result>((int)(endingPoint - startingPoint));

            while (startingPoint < endingPoint)
            {
                listRequest.Start = 1;

                results.AddRange(listRequest.Execute().Items);
                startingPoint += GoogleSearchPagingConverter.GooglePageSize;
            }

            return results;
        }
    }
}
