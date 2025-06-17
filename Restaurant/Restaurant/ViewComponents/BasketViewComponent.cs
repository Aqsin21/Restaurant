using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DataContext;
using Restaurant.DataContext.Entities;
using Restaurant.Models;

namespace Restaurant.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public BasketViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var basket = Request.Cookies["Basket"];
            if (string.IsNullOrEmpty(basket))
            {
                return Content("0");
            }

            var basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(basket);

            var cart = new CartViewModel();
            var cartItemList = new List<CartItemViewModel>();
            
            foreach (var item in basketItems ?? [])
            {
                var menuitem = _dbContext.MenuItems.Find(item.MenuItemId);
                if (menuitem == null) continue;

                cartItemList.Add(new CartItemViewModel
                {
                    Name = menuitem.Name,
                    Description =menuitem.Description,
                    Price=menuitem.Price,
                    Quantity = item.Quantity



                });


            }
            cart.Items = cartItemList;
            cart.Quantity=cartItemList.Sum(x => x.Quantity);
            cart.Total=cartItemList.Sum(x=>x.Quantity*x.Price);

            return View(cart);





        }
    }
}
