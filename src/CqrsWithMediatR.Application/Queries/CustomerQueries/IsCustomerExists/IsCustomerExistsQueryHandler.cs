using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsWithMediatR.Queries.CustomerQueries.IsCustomerExists
{
    public class IsCustomerExistsQueryHandler : IRequestHandler<IsCustomerExistsQuery, bool>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;

        public IsCustomerExistsQueryHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsCustomerExistsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.AnyAsync(c => c.CustomerId == request.CustomerId, cancellationToken);
        }
    }
}
