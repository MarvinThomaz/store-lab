using System;
using System.Collections.Generic;

namespace Store.Common.List
{
	public interface IPagingList<T> : IList<T>
    {
        int Page { get; set; }
        int RecordsPerPage { get; set; }
        int TotalRecords { get; set; }
    }
}
