using Store.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Common.Intefaces
{
    public interface IDataAccess
    {
        Task InsertAsync<T>(T entity);
        Task UpdateAsync<T>(T entity, string key);
        Task UpdateAsync<T>(IDictionary<string, object> properties, string key);
        Task DeleteAsync<T>(string key);
        Task<T> SelectByKeyAsync<T>(string key);
        Task<T> SelectByQueryAsync<T>(Expression<Func<T, bool>> query);
        Task<IPagingList<T>> SelectAsync<T>(int page, int recordsPerPage);
        Task<IPagingList<T>> SelectAllByQueryAsync<T>(Expression<Func<T, bool>> query, int page, int recordsPerPage);
    }
}