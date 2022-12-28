#nullable disable
namespace Api.Models
{
    public class GroceryItem
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
