using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, Customer>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;

        public GetCustomerDetailsQueryHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.FindAsync(request.CustomerId);
        }
    }
}
