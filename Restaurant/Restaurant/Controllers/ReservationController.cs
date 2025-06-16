using Microsoft.AspNetCore.Mvc;
using Restaurant.DataContext;

namespace Restaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReservationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
