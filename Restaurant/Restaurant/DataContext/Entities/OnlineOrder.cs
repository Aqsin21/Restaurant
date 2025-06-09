using NuGet.Protocol;

namespace Restaurant.DataContext.Entities
{
    public class OnlineOrder
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public required string Adress { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
