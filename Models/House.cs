#nullable disable
namespace Api.Models
{
    public class House
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Member> Members { get; set; }
        public List<GroceryListItem> GroceryListItems { get; set; }
    }
}
