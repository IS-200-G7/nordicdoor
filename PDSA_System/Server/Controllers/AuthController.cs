using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;
using PDSA_System.Client;

namespace PDSA_System.Server.Controllers;

// URLene vil være av typen http://localhost:[port]/Auth/[endpoint]
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    // login controller
    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginFormData data)
    {
        // Hente til connection string fra appsettings.json og åpne en connection til database
        var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        using var conn = new DbHelper(connString).Connection;
        conn.Open();

        // Hent bruker fra database basert på epostadresse
        Bruker bruker;
        try
        {
            bruker = conn.QueryFirstOrDefault<Bruker>("SELECT * FROM Bruker WHERE Email = @brukernavn", new {data.brukernavn});
        }
        catch (Exception e)
        {
            Console.WriteLine($"databaseerror: {e.Message}");
            return StatusCode(500, "En feil har skjedd");
        }
        
        // Sjekk om bruker finnes
        if (bruker == null)
        {
            return StatusCode(401, "Feil brukernavn eller passord");
        }

        PasswordHash hasher = new PasswordHash();
        
        //hashString[0] er hash, hashString[1] er salt
        string[] hashString = bruker.PassordHash.Split(':');
        // base64 til byte array
        byte[] hash = Convert.FromBase64String(hashString[0]);
        byte[] salt = Convert.FromBase64String(hashString[1]);

        // Valider passordet ved å hashe det igjen med samme salt og sammenligne med resultat fra DB
        var valid = hasher.Verify(data.passord, salt, hash);
        
        // Send token om passordet er riktig
        if (valid)
        {
            JWTClaims claims = new JWTClaims(bruker.Email, bruker.Fornavn, bruker.Etternavn, "Bruker", bruker.BrukerId.ToString());

            var token = claims.GenerateToken();;
            
            return Ok(token);
        }
        
        // Feilmelding om passordet er feil
        return Unauthorized("Feil brukernavn eller passord");
    }


}