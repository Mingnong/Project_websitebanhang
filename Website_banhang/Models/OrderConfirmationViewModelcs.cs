using Website_banhang.Models;
namespace Website_banhang.Models
{
    public class OrderConfirmationViewModel
    {
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
