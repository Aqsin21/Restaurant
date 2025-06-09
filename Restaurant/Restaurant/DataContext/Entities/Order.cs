namespace Restaurant.DataContext.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public DateTime OrderTime { get; set; }
        public required Customer Customer { get; set; }
        public required Table Table { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
