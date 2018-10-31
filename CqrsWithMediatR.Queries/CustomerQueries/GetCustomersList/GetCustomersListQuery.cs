using System;
using System.Collections.Generic;
using System.Text;
using CqrsWithMediatR.Models;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<Customer>>
    {
    }
}
