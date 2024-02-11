using Microsoft.EntityFrameworkCore;
using RazorModels.Model;


namespace DatabaseAccess.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
    }
}
