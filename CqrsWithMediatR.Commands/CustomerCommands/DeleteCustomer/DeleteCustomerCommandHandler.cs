using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.DataAccessLayer;
using CqrsWithMediatR.Models;
using MediatR;

namespace CqrsWithMediatR.Commands.CustomerCommands.DeleteCustomer
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
            Customer customerToBeDeleted = await _dbContext.Customers.FindAsync(request.CustomerId);
            if (customerToBeDeleted != null)
            {
                _dbContext.Customers.Remove(customerToBeDeleted);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}
