using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Store.Common.List;

namespace Store.Common.Infra
{
    public class MongoDataAccess : IDataAccess
    {
        private readonly IMongoDatabase _mongoDataBase;

        public MongoDataAccess(IMongoDatabase mongoDataBase)
        {
            _mongoDataBase = mongoDataBase;
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync<T>(T entity)
        {
            var entityName = entity.GetType().Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);

            await collection.InsertOneAsync(entity);
        }

        public Task<IPagingList<T>> SelectAsync<T>(string page, string recordsPerPage)
        {
            throw new NotImplementedException();
        }

        public Task<IPagingList<T>> SelectAllByQueryAsync<T>(Expression<Func<T, bool>> query, string page, string recordsPerPage)
        {
            throw new NotImplementedException();
        }

        public async Task<T> SelectByKeyAsync<T>(string key)
        {
            var query = $"{{'_id': '{key}'}}";
            var entityName = typeof(T).Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);
            var entities = await collection.FindAsync(query);

            return await entities?.FirstAsync();
        }

        public Task<T> SelectByQueryAsync<T>(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync<T>(T entity, string key)
        {
            var entityName = entity.GetType().Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);
            var query = $"{{'_id': '{key}'}}";

            await collection.ReplaceOneAsync(query, entity);
        }
    }
}