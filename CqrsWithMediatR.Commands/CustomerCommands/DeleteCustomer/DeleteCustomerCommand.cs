using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CqrsWithMediatR.Commands.CustomerCommands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public long CustomerId { get; set; }
    }
}
