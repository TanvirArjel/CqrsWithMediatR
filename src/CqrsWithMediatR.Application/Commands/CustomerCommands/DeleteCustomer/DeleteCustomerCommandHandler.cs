using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;

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
