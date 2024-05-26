
using Appointment.SDK.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Appointment.SDK.Backend.Utilities;
using Configuration.Entities;

namespace Appointment.Configuration.Controllers;

public class EmployeeController(IServiceProvider serviceProvider) : StandardController<Employee, EmployeeValidator>(serviceProvider)
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        return this.ExternalSignIn("api/employee/signin-google");
    }
    [HttpGet("signin-google")]
    public async Task<IActionResult> GoogleLogin()
    {
      var response = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      if(response.Principal == null) return BadRequest();

      return Ok();
    }
}