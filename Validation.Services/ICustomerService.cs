using Validation.Domain;
using Validation.Services.Dtos;
using Validation.Domain.Responses;

namespace Validation.Services
{
    public interface ICustomerService
    {
        CustomerResult CreateCustomer(CustomerCreateDto customer);
        CustomerResult EditCustomer(int id, CustomerCreateDto customer);
        CustomerReadDto[] GetCustomers();
        CustomerReadDto? GetCustomerById(int id);
    }
}