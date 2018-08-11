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

        public static IEnumerable<T> Aggregate<T>(this IEnumerable<T> source, params IEnumerable<T>[] lists)
        {
            var sourceList = source.ToList();

            foreach (var list in lists)
            {
                sourceList.AddRange(list);
            }

            return sourceList;
        }
    }
}
