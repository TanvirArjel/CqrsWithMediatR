using CqrsWithMediatR.Domain.Entities;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<Customer>
    {
        public long CustomerId { get; set; }
    }
}
