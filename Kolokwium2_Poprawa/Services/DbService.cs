using Kolokwium2_Poprawa.Data;
using Kolokwium2_Poprawa.DTOs;
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

    public async Task<ClientDto> GetClientWithRentals(int clientId)
    {
        var client = await _context.Clients
            .Include(c => c.Rentals)
            .ThenInclude(r => r.Car)
            .ThenInclude(car => car.Model)
            .Include(c => c.Rentals)
            .ThenInclude(r => r.Car)
            .ThenInclude(car => car.Color)
            .FirstOrDefaultAsync(c => c.ID == clientId);

        if (client == null)
            return null;

        var clientDto = new ClientDto
        {
            ID = client.ID,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Address = client.Address,
            Rentals = client.Rentals.Select(r => new CarRentalDto
            {
                Car = new CarDto
                {
                    VIN = r.Car.VIN,
                    Name = r.Car.Name,
                    Seats = r.Car.Seats,
                    PricePerDay = r.Car.PricePerDay,
                    Model = new ModelDto
                    {
                        Name = r.Car.Model.Name
                    },
                    Color = new ColorDto
                    {
                        Name = r.Car.Color.Name
                    }
                }
            }).ToList()
        };

        return clientDto;
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