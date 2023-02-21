using FluentValidation;
using Validation.Services.Dtos;

namespace Validation.Services.Validators
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
