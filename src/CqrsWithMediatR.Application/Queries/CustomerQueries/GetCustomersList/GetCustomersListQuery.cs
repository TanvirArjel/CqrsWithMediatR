using System.Collections.Generic;
using CqrsWithMediatR.Domain.Entities;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<Customer>>
    {
    }
}
