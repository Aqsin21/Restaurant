namespace Restaurant.DataContext.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public  required string ImageUrl { get; set; }
        public  Category? Category { get; set; } 
        public bool IsAvaliable { get; set; }










    }
}
