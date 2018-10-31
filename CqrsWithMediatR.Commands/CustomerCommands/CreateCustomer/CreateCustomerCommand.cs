using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CqrsWithMediatR.Commands.CustomerCommands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
