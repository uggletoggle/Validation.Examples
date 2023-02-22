using Validation.Domain;

namespace Validation.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private int currentIndex = 2;
        private readonly List<Customer> _db = new()
            {
                John(),
                Jane()
            };

        public Customer[] GetCustomers() => _db.ToArray();

        public void Update(Customer customer)
        {
            var index = _db.IndexOf(_db.SingleOrDefault(c => c.Id == customer.Id));

            _db[index].Email = customer.Email;
            _db[index].Addresses = customer.Addresses;
            _db[index].Name = customer.Name;
        }

        public void Create(Customer customer)
        {
            customer.Id = ++currentIndex;
            _db.Add(customer);
        }
        public Customer? GetById(int id) => _db.FirstOrDefault(c => c.Id == id);


        #region PRIVATE METHODS

        private static Customer John() => new Customer
        {
            Id = 1,
            Name = "John",
            Email = "john@testmail.com",
            Addresses = new[]
            {
                new Address
                {
                    Street = "123 Main St",
                    City = "New York",
                    State = "NY",
                    ZipCode = "12345"
                }
            }
        };

        private static Customer Jane() => new Customer
        {
            Id = 2,
            Name = "Jane",
            Email = "jane@testmail.com",
            Addresses = new[]
            {
                new Address
                {
                    Street = "456 Main St",
                    City = "New York",
                    State = "NY",
                    ZipCode = "456789"
                }
                
            }
        };
        #endregion
    }
}