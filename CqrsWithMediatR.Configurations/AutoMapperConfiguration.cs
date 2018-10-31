using System;
using AutoMapper;
using CqrsWithMediatR.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsWithMediatR.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
