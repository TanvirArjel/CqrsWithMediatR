using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsWithMediatR.Application.Commands.CustomerCommands.UpdateCustomer
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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Customer customerToBeUpdated = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);

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
