using System;
using System.Collections.Generic;

namespace Store.Common.List
{
    public interface IPagingList<T> : IReadOnlyList<T>
    {
        int Page { get; }
        int RecordsPerPage { get; }
        int TotalRecords { get; }
    }
}
