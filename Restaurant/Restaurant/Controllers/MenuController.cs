using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataContext;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MenuController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var menuItems = _dbContext.MenuItems.Include(m => m.Category).ToList();
            return View(menuItems);
        }
    }
}
