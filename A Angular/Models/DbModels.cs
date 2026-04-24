using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A_Angular.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required, StringLength(40)]
        public string ItemName { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Stock { get; set; }
    }
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
