using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Store.Common.Google;
using Store.Common.Intefaces;
using Store.Common.Interfaces;
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

        public static void AddGoogleStorage(this IServiceCollection services, GoogleCloudAuthenticationSettings settings = null)
        {
            services.AddScoped(svcProvider =>
            {
                settings = settings ?? svcProvider.GetService<GoogleCloudAuthenticationSettings>();

                var contractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
                var serializeSettins = new JsonSerializerSettings { ContractResolver = contractResolver };
                var jsonSettings = JsonConvert.SerializeObject(settings, serializeSettins);
                var credential = GoogleCredential.FromJson(jsonSettings).CreateScoped(new[] { StorageService.Scope.DevstorageReadWrite });

                return StorageClient.Create(credential);
            });

            services.AddScoped<IFileUploader, GoogleCloudFileUploader>();
        }
    }
}