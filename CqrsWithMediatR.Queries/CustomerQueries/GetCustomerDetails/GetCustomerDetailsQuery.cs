using System;
using System.Collections.Generic;
using System.Text;
using CqrsWithMediatR.Models;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery: IRequest<Customer>
    {
        public long CustomerId { get; set; }
    }
}
