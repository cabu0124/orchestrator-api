using AutoMapper;
using Entities.Mapping.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Mapping
{
    public static class MappingDI
    {
        public static void AddMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ParameterProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
