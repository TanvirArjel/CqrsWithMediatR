using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CqrsWithMediatR.Queries.CustomerQueries.IsCustomerExists
{
    public class IsCustomerExistsQuery : IRequest<bool>
    {
        public long CustomerId { get; set; }
    }
}
