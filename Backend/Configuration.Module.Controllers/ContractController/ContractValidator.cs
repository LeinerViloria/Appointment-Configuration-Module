
using Appointment.Globals.Enums;
using Appointment.SDK.Backend.Database;
using Appointment.SDK.Backend.Validations;
using Configuration.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Configuration.Controllers;

public class ContractValidator : BaseControllerValidator<Contract>
{
    private readonly IServiceProvider ServiceProvider;
    public ContractValidator(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        var LimitToCreateContrat = 5;

        RuleFor(x => x.InitialDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now).AddDays(-LimitToCreateContrat))
            .WithMessage($"El plazo para crear un contrato es de {LimitToCreateContrat} días");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.InitialDate);

        RuleFor(x => x)
            .Must(EmployeeHasNoContract)
            .WithMessage("El empleado ya se encuentra con un contrato activo");
    }

    private bool EmployeeHasNoContract(Contract Item)
    {
        dynamic factory = ServiceProvider.GetService(typeof(IDbContextFactory<StoreContext>))!;
        using(StoreContext Context = factory.CreateDbContext())
        {
            return !Context.Set<Contract>()
                .AsNoTracking()
                .Any(x => x.RowidEmployee == Item.RowidEmployee && 
                    x.Rowid != Item.Rowid &&
                    x.Status == EnumRecordStatus.Active);
        }
    }
}