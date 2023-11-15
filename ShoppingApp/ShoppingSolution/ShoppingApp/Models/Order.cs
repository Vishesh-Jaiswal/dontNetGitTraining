using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string Username { get; set; }
        public float OrderAmount {  get; set; }

        [ForeignKey("cartNumber")]
        public Cart Cart { get; set; }
    }
}
