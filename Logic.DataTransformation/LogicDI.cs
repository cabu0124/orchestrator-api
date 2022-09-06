using Data.Repository;
using Entities.Model.Common;
using Logic.DataTransformation.Parameters;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.DataTransformation
{
    public static class LogicDI
    {
        public static IServiceCollection AddComppnents(this IServiceCollection services)
        {
            services.AddScoped<IProductECMLogic, ProductECMLogic>();
            services.AddScoped<IProductMKTLogic, ProductMKTLogic>();
            services.AddScoped<IProductCSVLogic, ProductCSVLogic>();

            services.AddRepositories(AppEnviroment.DBConnection, AppEnviroment.DatabaseName);

            return services;
        }
    }
}
