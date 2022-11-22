using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PDSA_System.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class DebugController : ControllerBase
{
    private IConfiguration _configuration;

    public DebugController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    // Login controller
    [HttpGet("/debug/tokenRead")]
    [Authorize]
    public IActionResult Debug()
    {
        // Returnerer tom string dersom `fornavn` ikke er definert. Slipper da feilmelding på grunn av nullverdier
        var fornavn = HttpContext.User.Identities.First().Claims.FirstOrDefault(claim => claim.Type == "fornavn")
            ?.Value;

        return Ok("Hei, " + fornavn);
    }
}
