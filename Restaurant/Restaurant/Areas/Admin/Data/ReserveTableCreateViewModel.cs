using Restaurant.DataContext.Entities;

namespace Restaurant.Areas.Admin.Data
{
    public class ReserveTableCreateViewModel
    {
        public int TableId { get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public required List<ReserveTable> ReserveTables { get; set; }


    }
}
