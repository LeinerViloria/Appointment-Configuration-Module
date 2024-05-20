
using Appointment.Globals.Enums;
using Appointment.SDK.Backend.Database;
using Appointment.SDK.Backend.Validations;
using Configuration.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Configuration.Controllers;

public class ContractValidator : BaseControllerValidator<Contract>
{
    private readonly IDbContextFactory<StoreContext> dbContext;
    public ContractValidator(IDbContextFactory<StoreContext> dbContextFactory)
    {
        dbContext = dbContextFactory;

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.InitialDate);

        RuleFor(x => x)
            .Must(EmployeeHasNoContract)
            .WithMessage("El empleado ya se encuentra con un contrato activo");
    }

    private bool EmployeeHasNoContract(Contract Item)
    {
        using(var Context = dbContext.CreateDbContext())
        {
            return !Context.Set<Contract>()
                .AsNoTracking()
                .Any(x => x.RowidEmployee == Item.RowidEmployee && 
                    x.Rowid != Item.Rowid &&
                    x.Status == EnumRecordStatus.Active);
        }
    }
}