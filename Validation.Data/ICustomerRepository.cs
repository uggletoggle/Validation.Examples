using Validation.Domain;

namespace Validation.Data
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer? GetById(int id);
        Customer[] GetCustomers();
        void Update(Customer customer);
    }
}