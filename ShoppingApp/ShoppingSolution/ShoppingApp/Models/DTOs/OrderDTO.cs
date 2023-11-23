using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models.DTOs
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "Username is empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Product Id is empty")]
        public int CartNumber { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
