using Dapper;
using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;

namespace PDSA_System.Server.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private IConfiguration _configuration;
    public StatusController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    // status controller
    [HttpPost]
    public async Task<ActionResult<List<Forslag>>> SetStatus([FromQuery] int ForslagId, [FromQuery] string Status)
    {   // Hente til connection string fra appsettings.json og åpne en connection til database
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;
        conn.Open();

        // En array med statuser som er lov å bruke
        string[] acceptedStatuses = { "plan", "do", "study", "act" };

        // Sjekker om statusen som vi har fått er i acceptedStatuses
        if (!acceptedStatuses.Contains(Status))
        {
            return StatusCode(400, "Invalid value for 'Status'. Must be 'plan', 'do', 'study' or 'act'");
        }

        // Prøv skrive statusen inn i databasen
        try
        {
            await conn.QueryAsync<int>("UPDATE Forslag SET Status = @Status WHERE ForslagId = @ForslagId", new { ForslagId = ForslagId, Status = Status });
        }
        catch (Exception e)
        {
            Console.WriteLine($"databaseerror: {e.Message}");
            return StatusCode(500, "En feil har skjedd");
        }
        return Ok();
    }
}
