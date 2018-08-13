using FizzWare.NBuilder;
using MongoDB.Driver;
using NSubstitute;
using Store.Common.Intefaces;
using Store.Common.Mongo;
using Store.Common.Tests.Unit.Fakes;
using System.Threading.Tasks;
using Xunit;

namespace Store.Common.Tests.Unit.Infra
{
    public class DataAccessTests
    {
        private readonly IMongoDatabase _mongoData = Substitute.For<IMongoDatabase>();
        private readonly IDataAccess _dataAccess;

        public DataAccessTests()
        {
            _dataAccess = new MongoDataAccess(_mongoData);
        }

        [Fact]
        public async Task InsertEntity()
        {
            var entity = Builder<Entity>.CreateNew().Build();
            var collection = Substitute.For<IMongoCollection<Entity>>();
            var entityName = entity.GetType().Name;

            _mongoData.GetCollection<Entity>(entityName).Returns(collection);

            await _dataAccess.InsertAsync(entity);

            _mongoData.Received(1).GetCollection<Entity>(entityName);

            await collection.Received(1).InsertOneAsync(entity);
        }

        [Fact]
        public async Task UpdateEntity()
        {
            var entity = Builder<Entity>.CreateNew().Build();
            var collection = Substitute.For<IMongoCollection<Entity>>();
            var query = $"{{'key': '{entity.Key}'}}";
            var entityName = entity.GetType().Name;

            _mongoData.GetCollection<Entity>(entityName).Returns(collection);

            await _dataAccess.UpdateAsync(entity, entity.Key);

            _mongoData.Received(1).GetCollection<Entity>(entityName);
        }
    }
}