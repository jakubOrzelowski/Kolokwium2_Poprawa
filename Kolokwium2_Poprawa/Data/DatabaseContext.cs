using System.Drawing;
using Kolokwium2_Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2_Poprawa.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cars> Cars { get; set; }
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Car_Rentals> CarRentals { get; set; }
    public DbSet<Models.Models> Models { get; set; }
    public DbSet<Colors> Colors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Models.Models>().HasData(
            new Models.Models { ID = 1, Name = "Toyota" },
            new Models.Models { ID = 2, Name = "Skoda" }
        );

        modelBuilder.Entity<Colors>().HasData(
            new Colors { ID = 1, Name = "white" },
            new Colors { ID = 2, Name = "black" }
        );

        modelBuilder.Entity<Cars>().HasData(
            new Cars { ID = 1, VIN = "2D4HN11EX9R686008", Name = "Camry", Seats = 4, PricePerDay = 120, ModelID = 1, ColorID = 1 },
            new Cars { ID = 2, VIN = "JTDBR32E630013672", Name = "Octavia", Seats = 4, PricePerDay = 170, ModelID = 2, ColorID = 2 }
        );

        modelBuilder.Entity<Clients>().HasData(
            new Clients { ID = 1, FirstName = "Jan", LastName = "Kowalski", Address = "Koszykowa 86" },
            new Clients { ID = 2, FirstName = "Ewa", LastName = "Nowak", Address = "Tulipanowa 5" }
        );

        modelBuilder.Entity<Car_Rentals>().HasData(
            new Car_Rentals { ID = 1, ClientID = 1, CarID = 1, DateFrom = new DateTime(2024, 6, 24), DateTo = new DateTime(2024, 6, 28), TotalPrice = 480, Discount = 0 },
            new Car_Rentals { ID = 2, ClientID = 1, CarID = 1, DateFrom = new DateTime(2024, 7, 1), DateTo = new DateTime(2024, 7, 5), TotalPrice = 360, Discount = 0 },
            new Car_Rentals { ID = 3, ClientID = 1, CarID = 2, DateFrom = new DateTime(2024, 8, 1), DateTo = new DateTime(2024, 8, 10), TotalPrice = 1530, Discount = 0 },
            new Car_Rentals { ID = 4, ClientID = 2, CarID = 2, DateFrom = new DateTime(2024, 6, 24), DateTo = new DateTime(2024, 6, 26), TotalPrice = 340, Discount = 0 }
        );
    }
}