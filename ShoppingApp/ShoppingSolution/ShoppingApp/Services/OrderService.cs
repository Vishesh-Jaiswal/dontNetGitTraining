using Microsoft.EntityFrameworkCore;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepository;
        private readonly IRepository<int,CartItems> _cartItemsRepository;


        public OrderService(IRepository<int, Order> orderRepository, IRepository<int, CartItems> cartItemsRepository)
        {
            _orderRepository = orderRepository;
            _cartItemsRepository = cartItemsRepository;
        }
        private IQueryable<CartItems> GetCartItems(int cartNumber)
        {
            throw new NotImplementedException();
        }
        public Order PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
