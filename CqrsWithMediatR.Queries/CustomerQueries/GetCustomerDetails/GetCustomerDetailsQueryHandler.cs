using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.DataAccessLayer;
using CqrsWithMediatR.Models;
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

        public Task<Customer> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Customers.FindAsync(request.CustomerId);
        }
    }
}
