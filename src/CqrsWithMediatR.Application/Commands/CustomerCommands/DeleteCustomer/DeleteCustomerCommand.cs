using MediatR;

namespace CqrsWithMediatR.Application.Commands.CustomerCommands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public long CustomerId { get; set; }
    }
}
