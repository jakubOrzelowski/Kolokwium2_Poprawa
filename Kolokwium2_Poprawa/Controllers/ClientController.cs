using Kolokwium2_Poprawa.DTOs;
using Kolokwium2_Poprawa.Models;
using Kolokwium2_Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2_Poprawa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IDbService _dbService;
    public ClientController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{clientId}")]
    public async Task<ActionResult<Clients>> GetClientWithRentals(int clientId)
    {
        var client = await _dbService.GetClientWithRentals(clientId);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult> AddClientWithRental([FromBody] ClientRentalDto dto)
    {
        var client = new Clients
        {
            FirstName = dto.Client.FirstName,
            LastName = dto.Client.LastName,
            Address = dto.Client.Address
        };
        await _dbService.AddClientWithRental(client, dto.CarId, dto.DateFrom, dto.DateTo);
        return CreatedAtAction(nameof(GetClientWithRentals), new { clientId = client.ID }, client);
    }
}