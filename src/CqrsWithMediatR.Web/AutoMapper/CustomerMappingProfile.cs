using AutoMapper;
using CqrsWithMediatR.Application.Commands.CustomerCommands.UpdateCustomer;
using CqrsWithMediatR.Domain.Entities;

namespace CqrsWithMediatR.Web.AutoMapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, UpdateCustomerCommand>();
        }
    }
}
