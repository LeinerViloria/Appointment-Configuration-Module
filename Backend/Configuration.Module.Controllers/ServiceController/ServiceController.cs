using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;

namespace Appointment.Configuration.Controllers;

public class ServiceController(IServiceProvider serviceProvider) : StandardController<Service, ServiceValidator>(serviceProvider)
{

}