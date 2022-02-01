using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_application.Models
{
    public class OrderItem
    {
        public int Id { get; set; } 
        public int?  Amount { get; set; }
        public double? Price { get; set; }
        
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int? MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
    }
}
