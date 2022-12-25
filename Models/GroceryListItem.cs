#nullable disable
namespace Api.Models
{
    public class GroceryListItem
    {
        public int Id { get; set; }
        public GroceryItem Item { get; set; }
        public int Quantity { get; set; }
    }
}
