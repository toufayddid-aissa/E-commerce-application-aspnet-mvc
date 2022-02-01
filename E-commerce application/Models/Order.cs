namespace E_commerce_application.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public String UserId { get; set; }
        public List<OrderItem>? orderItems { get; set; }
    }
}
