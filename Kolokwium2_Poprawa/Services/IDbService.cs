using Kolokwium2_Poprawa.Models;

namespace Kolokwium2_Poprawa.Services;

public interface IDbService
{
    Task<Clients> GetClientWithRentals(int clientId);
    Task AddClientWithRental(Clients client, int carId, DateTime dateFrom, DateTime dateTo);
}