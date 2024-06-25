using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2_Poprawa.Models;

[Table("models")]
public class Models
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
}