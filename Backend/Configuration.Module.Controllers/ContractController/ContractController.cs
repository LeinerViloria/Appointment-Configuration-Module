using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;

namespace Appointment.Configuration.Controllers;

public class ContractController(IServiceProvider serviceProvider) : StandardController<Contract, ContractValidator>(serviceProvider)
{

}