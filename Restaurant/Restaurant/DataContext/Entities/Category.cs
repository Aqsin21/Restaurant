using NuGet.Protocol;

namespace Restaurant.DataContext.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
