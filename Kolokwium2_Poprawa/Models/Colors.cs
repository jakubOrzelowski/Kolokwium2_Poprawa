using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_Poprawa.Models;

[Table("colors")]
public class Colors
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
}