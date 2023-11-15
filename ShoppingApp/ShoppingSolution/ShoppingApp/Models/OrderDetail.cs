using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class OrderDetail
    {
        public int OrderNumber { get; set; }
        public int Product_Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice {  get; set; }

        [ForeignKey("CartNumber")]
        public CartItems cartItems { get; set; }

    }
}
