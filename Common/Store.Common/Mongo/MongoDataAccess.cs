using MongoDB.Driver;
using Store.Common.Extensions;
using Store.Common.Intefaces;
using Store.Common.Interfaces;
using Store.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Common.Mongo
{
    public class MongoDataAccess : IDataAccess
    {
        private readonly IMongoDatabase _mongoDataBase;

        public MongoDataAccess(IMongoDatabase mongoDataBase)
        {
            _mongoDataBase = mongoDataBase;
        }

        public async Task DeleteAsync<T>(string key)
        {
            var query = $"{{'_id': '{key}'}}";
            var entityName = typeof(T).Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);

            await collection.DeleteOneAsync(query);
        }

        public async Task InsertAsync<T>(T entity)
        {
            var entityName = entity.GetType().Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);

            await collection.InsertOneAsync(entity);
        }

        public async Task<IPagingList<T>> SelectAsync<T>(int page, int recordsPerPage)
        {
            return await Task.Run(() => 
            { 
                var entityName = typeof(T).Name;
                var collection = _mongoDataBase.GetCollection<T>(entityName);
                var offset = (page - 1) * recordsPerPage;
                var query = collection.AsQueryable();
                var totalRecords = query.Skip(offset).Count();
                var list = query.Skip(offset).Take(recordsPerPage).ToList();

                return list.ToPagingList(page, recordsPerPage, totalRecords);
            });
        }

        public async Task<IPagingList<T>> SelectAllByQueryAsync<T>(Expression<Func<T, bool>> query, int page, int recordsPerPage)
        {
            return await Task.Run(() =>
            {
                var entityName = typeof(T).Name;
                var collection = _mongoDataBase.GetCollection<T>(entityName);
                var offset = (page - 1) * recordsPerPage;
                var queryable = collection.AsQueryable().Where(query);
                var totalRecords = queryable.Skip(offset).Count();
                var list = queryable.Skip(offset).Take(recordsPerPage).ToList();

                return list.ToPagingList(page, recordsPerPage, totalRecords);
            });
        }

        public async Task<T> SelectByKeyAsync<T>(string key)
        {
            var query = $"{{'_id': '{key}'}}";
            var entityName = typeof(T).Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);
            var entities = await collection.FindAsync(query);

            return await entities?.FirstAsync();
        }

        public async Task<T> SelectByQueryAsync<T>(Expression<Func<T, bool>> query)
        {
            var entityName = typeof(T).Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);
            var entities = await collection.FindAsync(query);

            return await entities?.FirstAsync();
        }

        public async Task UpdateAsync<T>(T entity, string key)
        {
            var entityName = entity.GetType().Name;
            var collection = _mongoDataBase.GetCollection<T>(entityName);
            var query = $"{{'_id': '{key}'}}";

            await collection.ReplaceOneAsync(query, entity);
        }

<<<<<<< HEAD:Store.Common/Infra/MongoDataAccess.cs
        public async Task UpdateAsync<T>(string key, IDictionary<string, object> properties)
        {
            var type = typeof(T);
            var entity = await SelectByKeyAsync<T>(key);

            foreach (var item in properties)
            {
                var property = type.GetProperty(item.Key);

                if(property != null)
                {
                    property.SetValue(entity, item.Value);
                }
=======
        public async Task UpdateAsync<T>(IDictionary<string, object> properties, string key)
        {
            var entity = await SelectByKeyAsync<T>(key);
            var entityProperties = properties.Select(p => GenericTypeUtils<T>.GetProperty(p.Key));

            foreach (var property in entityProperties)
            {
                property.SetValue(entity, properties[property.Name]);
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103:Common/Store.Common/Mongo/MongoDataAccess.cs
            }

            await UpdateAsync(entity, key);
        }
    }
}