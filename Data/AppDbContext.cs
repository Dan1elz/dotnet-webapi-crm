using Microsoft.EntityFrameworkCore;
using dotnet_webapi_erp.App.Models.Concrete;
using dotnet_webapi_erp.App.Models.Abstract;

namespace dotnet_webapi_erp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Association> Association { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<StockProduct> StockProduct { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Sale> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Data/Database", "api-erp.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information); //tirar depois 
            optionsBuilder.EnableSensitiveDataLogging(); // tirar depois

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.CPF).IsUnique();

            modelBuilder.Entity<Company>().HasIndex(p => p.CNPJ).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<dotnet_webapi_erp.App.Models.Abstract.BaseEntity> BaseEntity { get; set; } = default!;
    }
}
