using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using GoogleSearchLibrary.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Apis.Customsearch.v1.CseResource;

namespace GoogleSearchLibrary.Services
{
    public class GoogleSearchProcess : IGoogleSearchProcess
    {
        private ListRequest _listRequest;

        private ConfigurationModel _config;

        private long _resultsLimit;

        public GoogleSearchProcess(ConfigurationModel config)
        {
            _config = config;
        }

        public int CurrentPage { get; private set; }

        public int LoadedResults { get; private set; }

        public bool HasStarted { get; private set; }

        public bool HasMoreResults { get; private set; }

        public void SetUp(string text, long resultsLimit = 100)
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = _config.ApiKey });
            _listRequest = customSearchService.Cse.List(text);
            _listRequest.Cx = _config.EngineId;
            HasStarted = HasMoreResults = true;
            _resultsLimit = resultsLimit;
        }

        public IList<Result> GetResults(long startPoint)
        {
            if(!HasStarted)
            {
                throw new InvalidOperationException("GoogleSearchProcess has not been set up.");
            }

            _listRequest.Start = startPoint;
            IList<Result> items = GetResults();

            return items;
        }

        public void Finish()
        {
            CurrentPage = 0;
            LoadedResults = 0;
            HasStarted = false;
            HasMoreResults = true;
        }

        private IList<Result> GetResults()
        {
            var items = _listRequest.Execute().Items ?? new List<Result>();
            UpdateInnerState(items);

            return items;
        }

        private void UpdateInnerState(IList<Result> items)
        {
            LoadedResults += items.Count;
            bool hasExceededLimit = LoadedResults > _resultsLimit;
            HasMoreResults = items.Any() && !hasExceededLimit;
            CurrentPage++;
        }
    }
}
