using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CqrsWithMediatR.Commands.CustomerCommands.UpdateCustomer;
using CqrsWithMediatR.Models;

namespace CqrsWithMediatR.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, UpdateCustomerCommand>();
        }
    }
}
