using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        // Takes in a Product entity (check Entities > Product.cs) and 'Products' will be our table name
        public DbSet<Product> Products { get; set; }
    }
}