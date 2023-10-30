using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class CustomerService:ICustomerService
    {
        IRepository<string, Customer> repository;

        public CustomerService()
        {
            repository = new CustomerRepository();
        }
        public Customer AddCustomer(Customer customer)
        {
            var result = repository.Add(customer);
            if (result != null)
                return result;
            throw new UnableToAddCustomer();
        }
        public List<Customer> GetCustomers()
        {
            var customers = repository.GetAll();
            if (customers.Count != 0)
                return customers;
            throw new NoProductsAvailableException();
        }

        public bool Login(string username, string password)
        {
            var myCustomer = repository.GetById(username);
            if (myCustomer != null)
            {
                if (myCustomer.ComparePassword(password))
                    return true;
            }
            throw new UserNamePasswordIncorrect();
        }
    }
}
