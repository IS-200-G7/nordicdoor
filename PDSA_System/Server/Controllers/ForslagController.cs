using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;

namespace PDSA_System.Server.Controllers;


[Route("/api/[controller]")]
[ApiController]

public class ForslagController : Controller
{

    private readonly IConfiguration _configuration;

    public ForslagController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }


    /**
     * Henter alle Forslag fra databasen.
     * Returnerer statuskode 200 dersom det ikke oppstår feil.
     */
    [HttpGet]
    public async Task<ActionResult<List<Forslag>>> GetAllBrukere()
    {
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var forslag = await conn.QueryAsync<Forslag>("SELECT * FROM Forslag");

        return Ok(forslag);
    }
}
