using ShoppingApp.Models;
using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Interfaces
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
    }
}
