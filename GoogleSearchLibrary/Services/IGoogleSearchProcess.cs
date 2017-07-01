using Google.Apis.Customsearch.v1.Data;
using System.Collections.Generic;

namespace GoogleSearchLibrary.Services
{
    public interface IGoogleSearchProcess
    {
        int CurrentPage { get; }

        int LoadedResults { get; }

        bool HasStarted { get; }

        bool HasMoreResults { get; }

        void SetUp(string text, long resultsLimit = 100);

        IList<Result> GetResults(long startPoint);

        void Finish();
    }
}
