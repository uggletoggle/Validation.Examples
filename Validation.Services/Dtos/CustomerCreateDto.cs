namespace Validation.Services.Dtos
{
    public class CustomerCreateDto
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public AddressDto[] Addresses { get; set; }
    }
}
