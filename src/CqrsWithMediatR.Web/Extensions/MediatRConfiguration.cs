using CqrsWithMediatR.Application.Commands.CustomerCommands.CreateCustomer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsWithMediatR.Web.Extensions
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly);
        }
    }
}
