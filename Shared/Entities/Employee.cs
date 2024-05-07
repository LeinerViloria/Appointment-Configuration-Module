
using System.ComponentModel.DataAnnotations;
using Appointment.Globals.Enums;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Employee : BaseCompany<int>
{
    [Required]
    public string Id { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public EnumRecordStatus Status { get; set; }
    [Required]
    public EnumGender Gender { get; set; }

}