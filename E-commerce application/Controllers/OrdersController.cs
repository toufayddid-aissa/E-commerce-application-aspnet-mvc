using E_commerce_application.Data.Cart;
using E_commerce_application.Data.Cart;
using E_commerce_application.Data.Services;
using E_commerce_application.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_application.Controllers
{
    public class OrdersController : Controller
    {
        private IMovieService _service;
        private ShopingCart _shopingCart;
        public OrdersController(IMovieService service , ShopingCart shopingCart)
        {
            _service = service;
            _shopingCart = shopingCart;


        }
        public IActionResult Index()
        {
            var shopingCart = _shopingCart.AddShopingCartItm();
            _shopingCart.ShopingCartItms = shopingCart;
            var response = new ShopingCartVM()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal()
            };
            return View(response);  
        }
    }
}
