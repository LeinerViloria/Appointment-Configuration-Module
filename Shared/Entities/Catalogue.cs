using System.ComponentModel.DataAnnotations;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Catalogue : BaseEntity<int>
{
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<Service>? Services { get; set; }

    public override string ToString() => $"{Name}";
}