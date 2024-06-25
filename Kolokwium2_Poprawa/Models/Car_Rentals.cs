using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_Poprawa.Models;
[Table("car_rentals")]
public class Car_Rentals
{
    [Key]
    public int ID { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int TotalPrice { get; set; }
    public int? Discount { get; set; }

    public int ClientID { get; set; }
    public int CarID { get; set; }
    
    [ForeignKey(nameof(ClientID))]
    public Clients Client { get; set; } = null!;
    [ForeignKey(nameof(CarID))]
    public Cars Car { get; set; } = null!;
}