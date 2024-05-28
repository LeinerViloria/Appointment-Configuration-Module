using Appointment.SDK.Backend.Controllers;
using Configuration.Entities;
using Appointment.SDK.Backend.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Appointment.Configuration.Controllers;

public class CatalogueController(IServiceProvider serviceProvider) : StandardController<Catalogue, BaseControllerValidator<Catalogue>>(serviceProvider)
{
    [HttpGet("getDataWithServices")]
    public IActionResult GetDataWithServices()
    {
        using(var context = CreateContext())
        {
            context.ChangeTracker.LazyLoadingEnabled = false;
            var Data = context.Set<Catalogue>()
                .AsNoTracking()
                .Include(x => x.Services)
                .Select(x => new Catalogue(){
                    Rowid = x.Rowid,
                    Name = x.Name,
                    Services = x.Services == null ? null : x.Services.Select(y => new Service(){
                        Rowid = y.Rowid,
                        Name = y.Name,
                        Description = y.Description,
                        Price = y.Price,
                        RowidCatalogue = y.RowidCatalogue,
                        Status = y.Status
                    }).ToList()
                }).ToList();

            return Ok(Data);
        }
    }

}