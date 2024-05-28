using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;
using Appointment.SDK.Backend.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Configuration.Controllers;

public class CatalogueController(IServiceProvider serviceProvider) : StandardController<Catalogue, BaseControllerValidator<Catalogue>>(serviceProvider)
{
    [HttpGet("/getDataWithServices")]
    public IActionResult GetDataWithServices()
    {
        using(var context = CreateContext())
        {
            var Data = context.Set<Catalogue>()
                .AsNoTracking()
                .Include(x => x.Services)
                .ToList();

            return Ok(Data);
        }
    }

}