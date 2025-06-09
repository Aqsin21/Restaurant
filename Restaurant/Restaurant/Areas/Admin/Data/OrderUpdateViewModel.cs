using Restaurant.DataContext.Entities;

namespace Restaurant.Areas.Admin.Data
{
    public class OrderUpdateViewModel
    {
        public int TableId { get; set; }
        public DateTime OrderTime { get; set; }
        public required Table Table { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
