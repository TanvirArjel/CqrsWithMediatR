﻿using FluentValidation;

namespace CqrsWithMediatR.Commands.CustomerCommands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.CompanyName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(100).NotEmpty();
            RuleFor(x => x.City).MaximumLength(15).NotEmpty();
            RuleFor(x => x.PostalCode).MaximumLength(10).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(20).NotEmpty();
        }
    }
}
