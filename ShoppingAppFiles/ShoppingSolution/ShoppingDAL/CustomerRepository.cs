using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        public Customer Add(Customer item)
        {
            customers.Add(item.Email, item);
            return item;
        }


        public Customer Delete(string id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                customers.Remove(customer.Email);
                return customer;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            if (customers.Count == 0)
                return null;
            return customers.Values.ToList();
        }

        public Customer GetById(string id)
        {
            if (customers.ContainsKey(id))
            {
                return customers[id];
            }
            return null;
        }

        public Customer Update(Customer item)
        {
            var customer = GetById(item.Email);
            if (customer != null)
            {
                customers[item.Email] = item;
                return item;
            }
            return null;
        }
    }
}