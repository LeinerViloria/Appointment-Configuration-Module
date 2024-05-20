using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;
using Appointment.SDK.Backend.Validations;

namespace Appointment.Configuration.Controllers;

public class ContractController(IServiceProvider serviceProvider) : StandardController<Contract, BaseControllerValidator<Contract>>(serviceProvider)
{

}