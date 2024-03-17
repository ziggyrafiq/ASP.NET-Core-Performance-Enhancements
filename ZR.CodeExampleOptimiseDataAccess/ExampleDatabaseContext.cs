using Microsoft.EntityFrameworkCore;

namespace ZR.CodeExampleOptimiseDataAccess
{
    public class ExampleDatabaseContext : DbContext
    {
        public ExampleDatabaseContext(DbContextOptions<ExampleDatabaseContext> options)
            : base(options)
        {
        }

        // Define your DbSet for the User entity (replace User with your actual entity class)
        public DbSet<User> Users { get; set; }

        // Add your DbSet for other entities if needed

        // Configure your entities and relationships here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
