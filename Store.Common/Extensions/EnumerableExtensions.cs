using System;
using System.Collections.Generic;
using System.Linq;
using Store.Common.List;

namespace Store.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IPagingList<T> ToPagingList<T>(this IEnumerable<T> list, int page, int recordsPerPage, int totalRecords)
        {
            return new PagingList<T>(page, recordsPerPage, totalRecords, list.ToList());
        }
    }
}
