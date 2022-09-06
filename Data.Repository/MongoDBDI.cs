using Data.Repository.Collections;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public static class MongoDBDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string dbConnection, string dbName)
        {
            IMongoDBRepository mongoDB = new MongoDBRepository(dbConnection, dbName);
            services.AddSingleton(mongoDB);

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
