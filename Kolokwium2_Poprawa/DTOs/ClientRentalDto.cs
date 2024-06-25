namespace Kolokwium2_Poprawa.DTOs;

public class ClientRentalDto
{
    public ClientDto Client { get; set; }
    public int CarId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}



public class ClientDto
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public ICollection<CarRentalDto> Rentals { get; set; }
}

public class ColorDto
{
    public string Name { get; set; }
}

public class ModelDto
{
    public string Name { get; set; }
}

public class CarRentalDto
{
    public CarDto Car { get; set; }
}

public class CarDto
{
    public string VIN { get; set; }
    public ModelDto Model { get; set; }
    public ColorDto Color { get; set; }
    public string Name { get; set; }
    public int Seats { get; set; }
    public int PricePerDay { get; set; }
  
    
}



