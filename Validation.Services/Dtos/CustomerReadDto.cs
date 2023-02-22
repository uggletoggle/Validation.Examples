namespace Validation.Services.Dtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public AddressDto[] Addresses { get; set; }
    }
}
