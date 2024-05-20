using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;
using Appointment.SDK.Backend.Validations;

namespace Appointment.Configuration.Controllers;

public class ServiceController(IServiceProvider serviceProvider) : StandardController<Service, BaseControllerValidator<Service>>(serviceProvider)
{

}