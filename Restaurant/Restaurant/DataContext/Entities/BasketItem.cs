namespace Restaurant.DataContext.Entities
{
    public class BasketItem
    {
        public int MenuItemId { get; set; }
     
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
