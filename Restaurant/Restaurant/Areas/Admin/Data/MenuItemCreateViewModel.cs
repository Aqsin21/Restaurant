using Restaurant.DataContext.Entities;

namespace Restaurant.Areas.Admin.Data
{
    public class MenuItemCreateViewModel
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Img {  get; set; }
        public bool IsAvailable { get; set; }
        public required List<Category> Categories { get; set; }
    }
}












