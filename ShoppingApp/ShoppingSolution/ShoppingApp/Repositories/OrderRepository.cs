using ShoppingApp.Contexts;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        private readonly ShoppingContext _context;
        public OrderRepository(ShoppingContext context)
        {
            _context = context;
        }
        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
