using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Interfaces
{
    public interface IOrderService
    {
        bool PlaceOrder(OrderDTO orderDTO);
    }
}
