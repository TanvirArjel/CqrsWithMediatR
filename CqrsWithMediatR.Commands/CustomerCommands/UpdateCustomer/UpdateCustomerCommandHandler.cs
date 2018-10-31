using CqrsWithMediatR.DataAccessLayer;
using CqrsWithMediatR.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsWithMediatR.Commands.CustomerCommands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;

        public UpdateCustomerCommandHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customerToBeUpdated = await _dbContext.Customers.FindAsync(request.CustomerId);

            customerToBeUpdated.CustomerName = request.CustomerName;
            customerToBeUpdated.Address = request.Address;
            customerToBeUpdated.City = request.City;
            customerToBeUpdated.CompanyName = request.CompanyName;
            customerToBeUpdated.Country = request.Country;
            customerToBeUpdated.Phone = request.Phone;
            customerToBeUpdated.PostalCode = request.PostalCode;


            _dbContext.Customers.Update(customerToBeUpdated);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
