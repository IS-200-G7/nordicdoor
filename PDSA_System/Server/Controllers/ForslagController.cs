using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;
using PDSA_System.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

    /** GetAllForslag
     * @return - OkObjectResult
     * 
     * Hente ut alle forslagene
     */
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Forslag>>> GetAllForslag()
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var forslag = await conn.QueryAsync<Forslag>("SELECT * FROM Forslag");

        return Ok(forslag);
    }


    /** GetForslag
     * @param - int forslagsId
     * @return - OkObjectResult
     * 
     * Hente ut spesifikke forslag basert på forslagId
     */
    [HttpGet("/api/[controller]/{forslagId}")]
    [Authorize]
    public async Task<ActionResult<Forslag>> GetForslag(int forslagId)
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var forslag = await conn.QueryAsync<Forslag>("SELECT * FROM Forslag WHERE ForslagId = @id",
            new { id = forslagId });

        return Ok(forslag.First());
    }


    /** GetBrukerForslag
     * @param - int forfatterId
     * @return - OkObjectResult
     * 
     * Hent alle forslag til spesfikke brukere basert på forfatterId
     */
    [HttpGet("/api/[controller]/forfatter/{forfatterId}")]
    [Authorize]
    public async Task<ActionResult<List<Forslag>>> GetBrukerForslag(int forfatterId)
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var forslag = await conn.QueryAsync<Forslag>("SELECT * FROM Forslag WHERE ForfatterId = @id",
            new { id = forfatterId });

        return Ok(forslag);
    }


    /** CreateForslag
     * @param - int AnsattNr
     * @param - string Status
     * @return - OkObjectResult
     * 
     * Oprett et forslag
     * 
     * Fjernet bilde da det ikke fungerte å legge til pga kluss med datatype
     * Hvis den skal testes i swagger fjern bilde stringen og kjør
     */
    [HttpPost("/api/[controller]/createforslag/")]
    [Authorize]
    public async Task<ActionResult<bool>> CreateForslag(Forslag forslag)
    {
        var forfatterId = HttpContext.User.Identities.First().Claims.FirstOrDefault(claim => claim.Type == "brukerId")?.Value;
        forslag.ForfatterId = int.Parse(forfatterId);

        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var res = await conn.ExecuteAsync(
            "INSERT INTO Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Kategori) VALUES (@ForfatterId, @TeamId, @Emne, @Beskrivelse, @Kategori)",
            forslag);

        return Ok(res.Equals(1));
    }


    /** UpdateForslag
     * @param - Forslag forslag 
     * @return - OkObjectResult
     * 
     * Oppdater et forslag utifra forslagId
     */
    [HttpPut("/api/[controller]/updateforslag/{forslagId}")]
    [Authorize]
    public async Task<ActionResult<bool>> UpdateForslag(Forslag forslag)
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var res = await conn.ExecuteAsync(
            "UPDATE Forslag SET ForfatterId = @ForfatterId, TeamId = @TeamId, Emne = @Emne, Beskrivelse = @Beskrivelse, Bilde = @Bilde, Kategori = @Kategori, Status = @Status WHERE ForslagId = @ForslagId",
            forslag);

        return Ok(res.Equals(1));
    }


    /** DeleteForslag
     * @param - int forslagId 
     * @return - OkObjectResult
     * 
     * Slett et forslag utifra forslagId
     */
    [HttpDelete("/api/[controller]/deleteforslag/{forslagId}")]
    [Authorize]
    public async Task<ActionResult<bool>> DeleteForslag(int forslagId)
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        var res = await conn.ExecuteAsync("DELETE FROM Forslag WHERE ForslagId = @id", new { id = forslagId });

        return Ok(res.Equals(1));
    }

    /** UpdateBilde
     * @param - IFormFile imageFile
     * @param - int forslagId
     * @return - OkObjectResult
     * 
     * Last opp et bilde
     */
    [HttpPost("/api/[controller]/UpdateBilde/")]
    public async Task<ActionResult<bool>> UpdateBilde(IFormFile imageFile, int forslagId)
    {
        // Lag en kobling til databasen
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;

        string filePath = Path.GetTempFileName();
        using (var stream = System.IO.File.Create(filePath))
        {
            await imageFile.CopyToAsync(stream);
        }
        // Converts image file into byte[]
        byte[] imageData = await System.IO.File.ReadAllBytesAsync(filePath);

        var parameters = new DynamicParameters();
        parameters.Add("@Bilde", imageData, DbType.Binary);
        parameters.Add("@Id", forslagId);

        var res = await conn.ExecuteAsync("UPDATE Forslag SET Bilde = @Bilde WHERE ForslagId = @Id", parameters);

        return Ok(res.Equals(1));
    }
}
