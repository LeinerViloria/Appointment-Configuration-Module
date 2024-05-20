using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appointment.Globals.Enums;
using Appointment.SDK.Entities;

namespace Configuration.Entities;

public class Contract : BaseEntity<int>
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public EnumRecordStatus Status { get; set; }
    [Required]
    public DateOnly InitialDate {get; set;}
    public DateOnly? EndDate {get; set;}
    [ForeignKey("Employee")]
    [Required]
    public int RowidEmployee {get; set;}
    public Employee? Employee{ get; set;}
}