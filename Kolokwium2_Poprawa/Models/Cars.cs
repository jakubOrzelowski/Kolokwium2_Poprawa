using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_Poprawa.Models;
[Table("cars")]
public class Cars
{
    [Key]
    public int ID { get; set; }
    [MaxLength(17)]
    public string VIN { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int Seats { get; set; }
    public int PricePerDay { get; set; }
    
    public int ModelID { get; set; }
    public int ColorID { get; set; }
    
    [ForeignKey(nameof(ModelID))]
    public Models Model { get; set; } = null!;
    [ForeignKey(nameof(ColorID))]
    public Colors Color { get; set; } = null!;
    
}