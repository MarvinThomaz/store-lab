using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Store.Common.Intefaces;
using Store.Common.Mongo;

namespace Store.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddScoped<IDataAccess, MongoDataAccess>();
        }

        public static void AddMongo(this IServiceCollection services, string database)
        {
            services.AddScoped(svcProvider =>
            {
                var configuration = svcProvider.GetService(typeof(IConfiguration)) as IConfiguration;
                var connStr = configuration.GetConnectionString("Mongo");
                var client = new MongoClient(connStr);

                return client.GetDatabase(database);
            });
        }
    }
}