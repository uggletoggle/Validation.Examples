using Validation.Services.Dtos;

namespace Validation.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerCreateDto customer);
        void EditCustomer(int id, CustomerCreateDto customer);
        CustomerReadDto[] GetCustomers();
        CustomerReadDto? GetCustomerById(int id);
    }
}