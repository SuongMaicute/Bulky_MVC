using bulkyweb.Models;
using Microsoft.EntityFrameworkCore;

namespace bulkyweb.Data
{
    public class BulkyDBContext : DbContext
    {
        public BulkyDBContext(DbContextOptions<BulkyDBContext> options) : base(options)
        {
            
        }

        public DbSet<Category>  Categories { get; set; }
        // override method to insert data from code to DB through Migrations and update-database 
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name ="Action", DisplayOrder ="1"},
                new Category { Id = 2, Name = "Scifi", DisplayOrder = "2" },
                new Category { Id = 3, Name = "History", DisplayOrder = "3" }
                );
        }
    
    
    
    }
}
