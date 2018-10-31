using CqrsWithMediatR.DataAccessLayer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Models;


namespace CqrsWithMediatR.Commands.CustomerCommands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly CqrsWithMediatRDbContext _dbContext;
        public CreateCustomerCommandHandler(CqrsWithMediatRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer
            {
                CustomerName = request.CustomerName,
                Address = request.Address,
                City = request.City,
                CompanyName = request.CompanyName,
                Country = request.Country,
                Phone = request.Phone,
                PostalCode = request.PostalCode
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
