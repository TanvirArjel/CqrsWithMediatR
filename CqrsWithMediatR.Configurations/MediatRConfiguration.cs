using CqrsWithMediatR.Commands.CustomerCommands.CreateCustomer;
using CqrsWithMediatR.Queries.CustomerQueries.GetCustomersList;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsWithMediatR.Configurations
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetCustomersListQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
