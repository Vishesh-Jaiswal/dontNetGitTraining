using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        public Customer AddCustomer(Customer customer);
      
        public List<Customer> GetCustomers();
        public bool Login(string username, string password);
    }
}
