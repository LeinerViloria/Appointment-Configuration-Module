using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appointment.Globals.Enums;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Catalogue : BaseCompany<int>
{
    [Required]
    public string Name { get; set; } = null!;
}