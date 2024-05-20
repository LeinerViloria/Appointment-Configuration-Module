using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;
using Appointment.SDK.Backend.Validations;

namespace Appointment.Configuration.Controllers;

public class CatalogueController(IServiceProvider serviceProvider) : StandardController<Catalogue, BaseControllerValidator<Catalogue>>(serviceProvider)
{

}