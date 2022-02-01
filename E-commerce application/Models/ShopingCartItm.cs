namespace E_commerce_application.Models
{
    public class ShopingCartItm
    {
        public int Id { get; set; }    
        public int Amount { get; set; }
        public Movie Movie  { get; set; }
        public int ShopingCartId    { get; set; }   
    }
}
