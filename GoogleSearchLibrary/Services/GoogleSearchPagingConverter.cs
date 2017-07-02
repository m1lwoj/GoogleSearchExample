namespace GoogleSearchLibrary.Services
{
    internal static class GoogleSearchPagingConverter
    {
        public static byte GooglePageSize = 10;

        public static long GetStartingPoint(int page, int pageSize)
        {
            return RoundDown((page - 1) * pageSize) + 1;
        }

        public static long GetEndingPoint(int page, int pageSize)
        {
            return RoundUp(page * pageSize);
        }

        public static int GetPagesCount(int page, int pageSize)
        {
            return (int)(RoundUp(page * pageSize) - GetStartingPoint(page, pageSize)) / GooglePageSize;
        }

        private static int RoundDown(int toRound)
        {
            return toRound - toRound % GooglePageSize;
        }

        private static int RoundUp(int toRound)
        {
            if (toRound % GooglePageSize == 0)
            {
                return toRound;
            }

            return (GooglePageSize - toRound % GooglePageSize) + toRound;
        }
    }
}
