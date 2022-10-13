using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDSA_System.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BrukerController : Controller
    {
        private readonly IConfiguration _configuration;

        public BrukerController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /**
         * Henter alle brukerene fra databasen.
         * Returnerer statuskode 200 dersom det ikke oppstår feil.
         */
        [HttpGet]
        public async Task<ActionResult<List<Bruker>>> GetAllBrukere()
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukere = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker");

            return Ok(brukere);
        }


        /**
         * Henter en spesifikk bruker iforhold til hvilken route man er på.
         * URL --> NordicDoor/Bruker/1 vil hente ut bruker med brukerId 1.
         * Returnerer statuskode 200 dersom det ikke oppstår feil.
        */
        [HttpGet("/api/[controller]/{brukerId}")]
        public async Task<ActionResult<List<Bruker>>> GetBruker(int brukerId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukere = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker WHERE BrukerId = @id",
                new { id = brukerId });

            return Ok(brukere);
        }

        /**
        * Sjekker om bruker har admin eller teamleder rolle, for å så legge til bruker i et Team
        */
        [HttpPost("/api/[controller]/addBrukerToTeam/")]
        public async Task<ActionResult<List<Bruker>>> OppdaterTeam(int TeamId, int BrukerId)
        {

            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("INSERT INTO TeamMedlemskap(TeamId, BrukerId) Values (@TeamId, @BrukerId)", new { TeamId = TeamId, BrukerId = BrukerId });


            return Ok();
        }


        /*
            Create for en ny Bruker.
         */
        [HttpPost("/api/[controller]/createBruker/")]
        public async Task<ActionResult<List<Bruker>>> CreateBruker(Bruker bruker)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "INSERT INTO Bruker(BrukerId, Fornavn, Etternavn, Email, PassordHash, Rolle, Opprettet, LederId) VALUES(@BrukerId, @Fornavn, @Etternavn, @Email, @PassordHash, @Rolle, @Opprettet, @LederId)",
                bruker);

            return Ok(await GetBruker(bruker.BrukerId));
        }

        /*
         Updater en Bruker --> ikke helt funksjonell enda.
         */
        [HttpPut("/api[Controller]/admin/UpdateBruker")]
        public async Task<ActionResult<List<Bruker>>> UpdateBruker(Bruker bruker)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "UPDATE Bruker SET Fornavn = @Fornavn, Etternavn = @Etternavn, Email = @Email, PassordHash = @PassordHash, LederId = @LederId, WHERE BrukerId = @BrukerId",
                bruker);

            return Ok(bruker);
        }


        /*
         Deleter brukere etter BrukerId
         */
        [HttpDelete("/api[controller]/admin/DeleteBruker")]
        public async Task<ActionResult<List<Bruker>>> DeleteBruker(int brukerId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "DELETE FROM Bruker WHERE BrukerId = @Id", new { id = brukerId });

            return Ok(await GetAllBrukere());
        }


        /*
        Denne metoden oppdaterer en Bruker sin Rolle med brukerId som betingelse.
        */
        [HttpPut("/api/[controller]/admin/updateBrukerRolle")]
        public async Task<ActionResult<List<Bruker>>> UpdateRolle(string rolle, int brukerId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "UPDATE Bruker SET Rolle = @Rolle WHERE BrukeriD = @Id", new { Rolle = rolle, Id = brukerId });

            return Ok(await GetAllBrukere());
        }

    }
}
