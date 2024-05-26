using Appointment.SDK.Backend.Database;
using Appointment.SDK.Backend.Validations;
using Configuration.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Configuration.Controllers;

public class EmployeeValidator : BaseControllerValidator<Employee>
{
    private readonly IServiceProvider ServiceProvider;
    public EmployeeValidator(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        RuleFor(x => x)
            .Must(ExistsEmployee)
            .WithMessage("El empleado ya existe")
            .WithName("Id");
    }

    private bool ExistsEmployee(Employee Item)
    {
        dynamic factory = ServiceProvider.GetService(typeof(IDbContextFactory<StoreContext>))!;
        using(StoreContext Context = factory.CreateDbContext())
        {
            return !Context.Set<Employee>()
                .AsNoTracking()
                .Any(x => x.Id == Item.Id);
        }
    }
}