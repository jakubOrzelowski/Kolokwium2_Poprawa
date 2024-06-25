using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_Poprawa.Models;

[Table("clients")]
public class Clients
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    
    public ICollection<Car_Rentals> Rentals { get; set; }
}