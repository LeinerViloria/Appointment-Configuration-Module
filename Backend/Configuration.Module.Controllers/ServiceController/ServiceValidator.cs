
using Appointment.Globals.Enums;
using Appointment.SDK.Backend.Database;
using Appointment.SDK.Backend.Validations;
using Configuration.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Configuration.Controllers;

public class ServiceValidator : BaseControllerValidator<Service>
{
    public ServiceValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0);
    }
}