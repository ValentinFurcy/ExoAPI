using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoAPI.Context
{
    public class ExoAPIContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ExoAPI;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var c1 = new Client() { Id = 1 , Name = "John" , Age = 42};
            var c2 = new Client() { Id = 2 , Name = "Croft" , Age = 39};
            var c3 = new Client() { Id = 3 , Name = "Dupont" , Age = 39};

            modelBuilder.Entity<Client>().HasData(c1);
            modelBuilder.Entity<Client>().HasData(c2);
            modelBuilder.Entity<Client>().HasData(c3);
            base.OnModelCreating(modelBuilder);
        }
    }
}
