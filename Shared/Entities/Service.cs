using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appointment.Globals.Enums;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Service : BaseEntity<int>
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }

    [Required]
    [ForeignKey("Catalogue")]
    public int RowidCatalogue {get; set;}
    public Catalogue? Catalogue{ get; set; }
}