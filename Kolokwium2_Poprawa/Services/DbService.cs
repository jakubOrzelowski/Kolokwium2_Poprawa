using Kolokwium2_Poprawa.Data;
using Kolokwium2_Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2_Poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Clients> GetClientWithRentals(int clientId)
    {
        return await _context.Clients
            .Include(c => c.Rentals)
            .ThenInclude(r => r.Car)
            .ThenInclude(car => car.Model)
            .Include(c => c.Rentals)
            .ThenInclude(r => r.Car)
            .ThenInclude(car => car.Color)
            .FirstOrDefaultAsync(c => c.ID == clientId);
    }

    public async Task AddClientWithRental(Clients client, int carId, DateTime dateFrom, DateTime dateTo)
    {
        var car = await _context.Cars.FindAsync(carId);
        if (car == null) throw new Exception("Car not found");

        client.Rentals = new List<Car_Rentals>
        {
            new Car_Rentals
            {
                CarID = carId,
                DateFrom = dateFrom,
                DateTo = dateTo,
                TotalPrice = (dateTo - dateFrom).Days * car.PricePerDay
            }
        };
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
    }
}