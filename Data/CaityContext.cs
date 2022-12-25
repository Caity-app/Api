#nullable disable
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class CaityContext : DbContext
    {
        public CaityContext(DbContextOptions options) : base(options) { }
        public DbSet<House> Houses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<GroceryListItem> GroceryListItems { get; set; }
    }
}
