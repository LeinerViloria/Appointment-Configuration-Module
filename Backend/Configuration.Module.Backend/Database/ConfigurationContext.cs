
using Appointment.SDK.Backend.Database;
using Configuration.Entities;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Module.Backend.Database;

public class ConfigurationContext(DbContextOptions options) : StoreContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Catalogue> Catalogues { get; set; }
    public DbSet<Service> Services { get; set; }
}