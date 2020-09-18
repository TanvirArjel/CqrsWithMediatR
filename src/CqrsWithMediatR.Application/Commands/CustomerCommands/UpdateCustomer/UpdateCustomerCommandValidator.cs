using FluentValidation;

namespace CqrsWithMediatR.Application.Commands.CustomerCommands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.CustomerName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.CompanyName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(100).NotEmpty();
            RuleFor(x => x.City).MaximumLength(15).NotEmpty();
            RuleFor(x => x.PostalCode).MaximumLength(10).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(20).NotEmpty();

            RuleFor(c => c.Country).Matches(@"^[a-zA-Z]+$").WithMessage("Country name should contain only alphabets!");
            RuleFor(c => c.PostalCode).Matches(@"^\d{4}$").WithMessage("Postal code should be 4 digits");
        }
    }
}
