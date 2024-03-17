using Microsoft.EntityFrameworkCore;
using ZR.CodeExampleEmbarkingAsynchronousOdyssey.Models;

namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Data
{
    public class ExampleDatabaseContext : DbContext
    {
        public ExampleDatabaseContext(DbContextOptions<ExampleDatabaseContext> options)
            : base(options)
        {
        }

        // Define your DbSet for the Person entity (replace Person with your actual entity class)
        public DbSet<Person> Persons { get; set; }

        // Configure your entities and relationships here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings and relationships here if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
