using E_commerce_application.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Data.Cart
{
    public class ShopingCart
    {
        private AddDbContext _context ;
       
        public int ShopinCartId { get; set; } 
        public List<ShopingCartItm> ShopingCartItms { get; set; }
        public ShopingCart(AddDbContext context)
        {
            _context = context;

        }
        public void AddItmToCart(Movie movie)
        {
            var ShopingCartItm = _context.ShopingCartItms.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShopingCartId == ShopinCartId) ;
            if (ShopingCartItm != null) ShopingCartItm.Amount++;
            else
            {
                ShopingCartItm = new ShopingCartItm()
                {
                    ShopingCartId = ShopinCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShopingCartItms.Add(ShopingCartItm);
            }
            _context.SaveChanges();
        }
        public void RemoveItmfromCart(Movie movie)
        {
            var ShopingCartItm = _context.ShopingCartItms.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShopingCartId == ShopinCartId);
            if (ShopingCartItm != null)
            {
                if(ShopingCartItm.Amount>1) ShopingCartItm.Amount--;
                _context.ShopingCartItms.Remove(ShopingCartItm);
                
            }
            
            _context.SaveChanges();
        }
        public List<ShopingCartItm> AddShopingCartItm()
        {
            return ShopingCartItms ?? (ShopingCartItms = _context.ShopingCartItms.Where(n => n.ShopingCartId == ShopinCartId).Include(n => n.Movie).ToList());
        }
        public double GetShopingCartTotal()
        {
            return _context.ShopingCartItms.Where(n => n.ShopingCartId == ShopinCartId).Select(n => n.Movie.Price * n.Amount).Sum();
        }

    }
}
