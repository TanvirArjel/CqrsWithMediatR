using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.DataAccessLayer;
using CqrsWithMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<Customer>>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;
        public GetCustomersListQueryHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }
    }
}
