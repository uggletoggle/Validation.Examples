using Validation.Data;
using Validation.Domain;

namespace Validation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public void CreateCustomer(CustomerCreateDto customer)
        {
            var customerEntity = MapToEntity(customer);
            _repo.Create(customerEntity);
        }

        public void EditCustomer(int id, CustomerCreateDto customer)
        {
            var customerEntity = MapToEntity(customer);
            customerEntity.Id = id;

            _repo.Update(customerEntity);
        }

        public CustomerReadDto? GetCustomerById(int id) => MapToReadDto(_repo.GetById(id));

        public CustomerReadDto[] GetCustomers() => _repo.GetCustomers().Select(MapToReadDto).ToArray();


        private Customer MapToEntity(CustomerCreateDto customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address
            };
        }

        private CustomerReadDto MapToReadDto(Customer customer)
        {
            return new CustomerReadDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address
            };
        }



    }
}
