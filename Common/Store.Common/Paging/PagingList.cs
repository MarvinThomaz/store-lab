using Store.Common.Interfaces;
using System.Collections.Generic;

namespace Store.Common.Paging
{
    public class PagingList<T> : IPagingList<T>
    {
        public PagingList(int page, int recordsPerPage, int totalRecords, IEnumerable<T> records)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            TotalRecords = totalRecords;
            Records = records;
        }

        public int Page { get; }
        public int RecordsPerPage { get; }
        public int TotalRecords { get; }
        public IEnumerable<T> Records { get; }
    }
}
