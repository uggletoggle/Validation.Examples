﻿using System.Text.RegularExpressions;
using Validation.Data;
using Validation.Domain;
using Validation.Domain.Responses;

namespace Validation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public CustomerResult CreateCustomer(CustomerCreateDto customer)
        {
            if (customer is null)
                return CustomerResult.Failure(new[] { "Customer object is required" }, errorCode: 400);
            
            if(string.IsNullOrEmpty(customer.Name))
                return CustomerResult.Failure(new[] { "Name is required" }, errorCode: 400);
            
            if(string.IsNullOrEmpty(customer.Email))
                return CustomerResult.Failure(new[] { "Email is required" }, errorCode: 400);
            
            if(string.IsNullOrEmpty(customer.Address))
                return CustomerResult.Failure(new[] { "Address is required" }, errorCode: 400);

            // regex for email
            var regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regexEmail.IsMatch(customer.Email))
                return CustomerResult.Failure(new[] { "Email is not valid" }, errorCode: 400);

            var customerEntity = MapToEntity(customer);
            _repo.Create(customerEntity);

            return CustomerResult.Ok(null);
        }

        public CustomerResult EditCustomer(int id, CustomerCreateDto customer)
        {
                
            if (customer is null)
                return CustomerResult.Failure(new[] { "Customer object is required" }, errorCode: 400);

            if (string.IsNullOrEmpty(customer.Name))
                return CustomerResult.Failure(new[] { "Name is required" }, errorCode: 400);

            if (string.IsNullOrEmpty(customer.Email))
                return CustomerResult.Failure(new[] { "Email is required" }, errorCode: 400);

            if (string.IsNullOrEmpty(customer.Address))
                return CustomerResult.Failure(new[] { "Address is required" }, errorCode: 400);

            // regex for email
            var regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regexEmail.IsMatch(customer.Email))
                return CustomerResult.Failure(new[] { "Email is not valid" }, errorCode: 400);

            var entityToEdit = _repo.GetById(id);

            if(entityToEdit is null)
                return CustomerResult.Failure(new[] { $"Customer not found for Id:{id}" }, errorCode: 404);

            var customerEntity = MapToEntity(customer);
            customerEntity.Id = id;

            _repo.Update(customerEntity);
            return CustomerResult.Ok(null);
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