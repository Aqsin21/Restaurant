using Microsoft.AspNetCore.Mvc;
using MimeKit.Encodings;
using Newtonsoft.Json;
using Restaurant.DataContext;
using Restaurant.DataContext.Entities;
using Restaurant.Models;


namespace Restaurant.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string BasketCookieKey = "Basket";

        public BasketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        private List<BasketItem> GetBasket()
        {
            var basket = Request.Cookies[BasketCookieKey];
            if (string.IsNullOrEmpty(basket))
            {
                return new List<BasketItem>();
            }
            var menuitems = JsonConvert.DeserializeObject<List<BasketItem>>(basket);
            if (menuitems == null)
            {
                return new List<BasketItem>();

            }
            return menuitems;
        }
        public IActionResult AddToBasket(int id)
        {
            var menuitem = _dbContext.MenuItems.Find(id);
                if (menuitem == null)
            {
                return BadRequest();
            }
            var basket = GetBasket();
            var existing = basket.FirstOrDefault(x => x.MenuItemId == id);
            if (existing != null)
            {
                existing.Quantity += 1;
            }
            else
            {
                basket.Add(new BasketItem
                {
                    MenuItemId = id,
                    Price = menuitem.Price,
                    Quantity = 1
                });
            }
            var basketJson =JsonConvert.SerializeObject(basket);
            Response.Cookies.Append(BasketCookieKey, basketJson, new CookieOptions 
            { 
                Expires = DateTimeOffset.Now.AddHours(1)
            });


            return RedirectToAction("Index", "Menu");
        }

      
    }
}