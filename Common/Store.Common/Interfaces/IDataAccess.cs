<<<<<<< HEAD:Store.Common/Infra/IDataAccess.cs
﻿using System;
=======
﻿using Store.Common.Interfaces;
using System;
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103:Common/Store.Common/Interfaces/IDataAccess.cs
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Common.Intefaces
{
    public interface IDataAccess
    {
        Task InsertAsync<T>(T entity);
        Task UpdateAsync<T>(T entity, string key);
<<<<<<< HEAD:Store.Common/Infra/IDataAccess.cs
        Task UpdateAsync<T>(string key, IDictionary<string, object> properties);
=======
        Task UpdateAsync<T>(IDictionary<string, object> properties, string key);
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103:Common/Store.Common/Interfaces/IDataAccess.cs
        Task DeleteAsync<T>(string key);
        Task<T> SelectByKeyAsync<T>(string key);
        Task<T> SelectByQueryAsync<T>(Expression<Func<T, bool>> query);
        Task<IPagingList<T>> SelectAsync<T>(int page, int recordsPerPage);
        Task<IPagingList<T>> SelectAllByQueryAsync<T>(Expression<Func<T, bool>> query, int page, int recordsPerPage);
    }
}