namespace Restaurant.DataContext.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName  { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
