using Microsoft.EntityFrameworkCore;
using RazorModels.Model;


namespace DatabaseAccess.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPOutput>().HasNoKey();
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
		public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<SPOutput> SPOutput { get; set; }
    }
}
