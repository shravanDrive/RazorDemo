using Microsoft.EntityFrameworkCore;
using RazorWeb.Model;

namespace RazorWeb.Data
{
    /// <summary>
    /// DB Context file created to connect to the Database
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}
