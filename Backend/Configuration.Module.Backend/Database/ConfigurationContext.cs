
using Appointment.SDK.Backend.Database;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Module.Backend.Database;

public class ConfigurationContext(DbContextOptions options) : StoreContext(options)
{
}