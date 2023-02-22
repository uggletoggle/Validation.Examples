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

            RuleFor(x => x.Addresses).NotNull()
                .Must(x => x.Length >= 1 && x.Length <= 3)
                .WithMessage("The number of addresses must be between 1 and 3");
            RuleForEach(x => x.Addresses).SetValidator(new AddressDtoValidator());
        }
    }
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.State).NotEmpty().Length(2, 2);
            RuleFor(x => x.Street).NotEmpty().Length(0, 200);
            RuleFor(x => x.City).NotEmpty().Length(0, 100);
            RuleFor(x => x.ZipCode).NotEmpty().Length(0, 5);
        }
    }
}
