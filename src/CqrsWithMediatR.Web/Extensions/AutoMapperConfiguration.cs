﻿using AutoMapper;
using CqrsWithMediatR.Web.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsWithMediatR.Web.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
