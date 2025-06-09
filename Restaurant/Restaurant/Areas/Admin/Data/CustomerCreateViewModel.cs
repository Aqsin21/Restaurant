namespace Restaurant.Areas.Admin.Data
{
    public class CustomerCreateViewModel
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
    }
}
