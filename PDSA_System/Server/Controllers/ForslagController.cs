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
    public async Task<ActionResult<List<Forslag>>> GetAllForslag()
    {
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var forslag = await conn.QueryAsync<Forslag>("SELECT * FROM Forslag");

        return Ok(forslag);
    }

    /**
    * Funksjon for å opprette forslag
    * Returnerer statuskode 200 dersom det ikke oppstår feil.
    * Fjernet bilde da det ikke fungerte å legge til pga kluss med datatype
     */
    [HttpPost("/api/[controller]/createforslag/")]
    public async Task<ActionResult<List<Forslag>>> CreateForslag(Forslag forslag)
    {
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        await conn.ExecuteAsync("INSERT INTO Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Kategori) VALUES (@ForfatterId, @TeamId, @Emne, @Beskrivelse, @Kategori)", forslag);

        return Ok(await GetAllForslag());
    }
}
