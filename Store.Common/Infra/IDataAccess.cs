using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.Common.List;

namespace Store.Common.Infra
{
    public interface IDataAccess
    {
        Task InsertAsync<T>(T entity);
        Task UpdateAsync<T>(T entity, string key);
        Task DeleteAsync(string key);
        Task<T> SelectByKeyAsync<T>(string key);
        Task<T> SelectByQueryAsync<T>(Expression<Func<T, bool>> query);
        Task<IPagingList<T>> SelectAsync<T>(string page, string recordsPerPage);
        Task<IPagingList<T>> SelectAllByQueryAsync<T>(Expression<Func<T, bool>> query, string page, string recordsPerPage);
    }
}