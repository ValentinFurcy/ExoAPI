using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoAPI.Context
{
    public class ExoAPIContext : DbContext
    {
        public ExoAPIContext() 
        {
        }

        public ExoAPIContext(DbContextOptions<ExoAPIContext> options) 
            : base(options) 
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ExoAPI;Integrated Security=True");


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var c1 = new Client() { Id = 1 , Name = "John" , Age = 42};
            var c2 = new Client() { Id = 2 , Name = "Croft" , Age = 39};
            var c3 = new Client() { Id = 3 , Name = "Dupont" , Age = 39};

            var o1 = new Order() { Id = 1, Number = 1, ClientId = c1.Id };
            var o2 = new Order() { Id = 2, Number = 2, ClientId = c2.Id };
            var o3 = new Order() { Id = 3, Number = 3, ClientId = c3.Id };

            modelBuilder.Entity<Client>().HasData(c1);
            modelBuilder.Entity<Client>().HasData(c2);
            modelBuilder.Entity<Client>().HasData(c3);
            modelBuilder.Entity<Order>().HasData(o1);
            modelBuilder.Entity<Order>().HasData(o2);
            modelBuilder.Entity<Order>().HasData(o3);
            base.OnModelCreating(modelBuilder);
        }
    }
}
