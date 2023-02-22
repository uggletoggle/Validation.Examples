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
            RuleFor(x => x.Address.State).NotEmpty().Length(2, 2);
            RuleFor(x => x.Address.Street).NotEmpty().Length(0, 200);
            RuleFor(x => x.Address.City).NotEmpty().Length(0, 100);
            RuleFor(x => x.Address.ZipCode).NotEmpty().Length(0, 5);
        }
    }
}
