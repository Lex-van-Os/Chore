using Microsoft.EntityFrameworkCore;
using ChoreApp.Shared;

namespace ChoreApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shared.Task>().HasData(
                new Shared.Task
                {
                    Id = 1,
                    Name = "Mails checken",
                    Done = false,
                    Description = "Beiden persoonlijk als werk",
                },
                new Shared.Task
                {
                    Id = 2,
                    Name = "Programmeerproject afmaken",
                    Done = false,
                    Description = "Minstens 3 nieuwe features",
                },
                new Shared.Task
                {
                    Id = 3,
                    Name = "Kamer opruimen",
                    Done = true,
                    Description = "Spik en span",
                }
            );
        }

        public DbSet<Shared.Task> Task { get; set; }
    }
}
