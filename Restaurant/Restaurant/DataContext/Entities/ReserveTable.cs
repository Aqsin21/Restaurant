namespace Restaurant.DataContext.Entities
{
   public class ReserveTable
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Email { get; set; }

        public DateTime ReservationDate { get; set; }  // Gün ve saat bilgisi için

        public TimeSpan ReservationTime { get; set; }  // Saat bilgisi için

        public int GuestCount { get; set; }

        public string? SpecialRequests { get; set; }  // Opsiyonel







    }
} 
