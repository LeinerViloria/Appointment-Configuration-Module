
using System.ComponentModel.DataAnnotations;
using Appointment.Globals.Enums;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Employee : BaseUser<int>
{
    [Required]
    public string Id { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public EnumGender Gender { get; set; }
    [Required]
    public bool IsAdmin { get; set; }

    public override string ToString() => $"({Id}) {Name}";

}