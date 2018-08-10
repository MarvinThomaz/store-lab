using System.Collections.Generic;

namespace Store.Common.List
{
    public class PagingList<T> : List<T>, IPagingList<T>
    {
        public PagingList(int page, int recordsPerPage, int totalRecords, List<T> list)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            TotalRecords = totalRecords;

            AddRange(list);
        }

        public int Page { get; }
        public int RecordsPerPage { get; }
        public int TotalRecords { get; }
    }
}
