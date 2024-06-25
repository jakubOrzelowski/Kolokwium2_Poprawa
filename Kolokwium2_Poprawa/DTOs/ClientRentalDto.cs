﻿namespace Kolokwium2_Poprawa.DTOs;

public class ClientRentalDto
{
    public ClientDto Client { get; set; }
    public int CarId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}