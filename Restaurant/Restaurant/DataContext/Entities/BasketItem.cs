namespace Restaurant.DataContext.Entities
{
    public class BasketItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
