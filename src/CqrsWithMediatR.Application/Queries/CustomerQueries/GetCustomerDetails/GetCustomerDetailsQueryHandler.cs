using System;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);
        }
    }
}
