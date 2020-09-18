using System;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsWithMediatR.Application.Commands.CustomerCommands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;
        public DeleteCustomerCommandHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Customer customerToBeDeleted = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);

            if (customerToBeDeleted != null)
            {
                _dbContext.Customers.Remove(customerToBeDeleted);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
