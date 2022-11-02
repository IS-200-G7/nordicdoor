using Microsoft.AspNetCore.Mvc;
using PDSA_System.Shared.Models;
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
         * URL --> NordicDoor/Bruker/1 vil hente ut bruker med AnsattNr 1.
         * Returnerer statuskode 200 dersom det ikke oppstår feil.
        */
        [HttpGet("/api/[controller]/{AnsattNr}")]
        public async Task<ActionResult<List<Bruker>>> GetBruker(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukere = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker WHERE AnsattNr = @id",
                new { id = AnsattNr });

            return Ok(brukere);
        }

        /**
        * Sjekker om bruker har admin eller teamleder rolle, for å så legge til bruker i et Team
        */
        [HttpPost("/api/[controller]/addBrukerToTeam/")]
        public async Task<ActionResult<List<Bruker>>> OppdaterTeam(int TeamId, int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("INSERT INTO TeamMedlemskap(TeamId, AnsattNr) Values (@TeamId, @AnsattNr)",
                new { TeamId = TeamId, AnsattNr = AnsattNr });


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
                "INSERT INTO Bruker(AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, Opprettet, LederId) VALUES(@AnsattNr, @Fornavn, @Etternavn, @Email, @PassordHash, @Rolle, @Opprettet, @LederId)",
                bruker);

            return Ok(await GetBruker(bruker.AnsattNr));
        }
        /*
         Updater en Bruker --> ikke helt funksjonell enda.
         */
        [HttpPut("/api[Controller]/admin/UpdateBruker/{AnsattNr}")]
        public async Task<ActionResult<List<Bruker>>> UpdateBruker(Bruker bruker)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "UPDATE Bruker SET Fornavn = @Fornavn, Etternavn = @Etternavn, Email = @Email, PassordHash = @PassordHash, LederId = @LederId, Rolle = @Rolle WHERE AnsattNr = @AnsattNr",
                bruker);

            return Ok(bruker);
        }


        /*
         Deleter brukere etter AnsattNr
         */
        [HttpDelete("/api[controller]/admin/DeleteBruker/{AnsattNr}")]
        public async Task<ActionResult<List<Bruker>>> DeleteBruker(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "DELETE FROM Bruker WHERE AnsattNr = @Id", new { id = AnsattNr });

            return Ok(await GetAllBrukere());
        }


        /*
        Denne metoden oppdaterer en Bruker sin Rolle med AnsattNr som betingelse.
        */
        [HttpPut("/api/[controller]/admin/updateBrukerRolle")]
        public async Task<ActionResult<List<Bruker>>> UpdateRolle(string rolle, int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "UPDATE Bruker SET Rolle = @Rolle WHERE AnsattNr = @Id", new { Rolle = rolle, Id = AnsattNr });

            return Ok(await GetAllBrukere());
        }

        [HttpPost("/api/[controller]/byttPassord/")]
        public async Task<ActionResult<bool>> ByttPassord([FromBody] ByttPassord data)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            // Forsøk å hente brukerId dersom ikke allerede definert
            if (data.BrukerId == 0)
            {
                data.BrukerId = Int32.Parse(HttpContext.User.Identities.First().Claims.FirstOrDefault(claim => claim.Type == "brukerId")?.Value ?? "0");
            }

            // Hvis BrukerId fortsatt er 0, da har de rotet det til
            if (data.BrukerId == 0)
            {
                return BadRequest(false);
            }

            var hasher = new PasswordHash();
            var salt = hasher.CreateSalt();
            var hash = hasher.HashPassword(data.Passord, salt);
            //byte to base64
            var hash2Base64 = Convert.ToBase64String(hash);
            var salt2Base64 = Convert.ToBase64String(salt);

            var res = await conn.ExecuteAsync("UPDATE Bruker SET PassordHash = @newHash WHERE AnsattNr = @Id",
                new { newHash = $"{hash2Base64}:{salt2Base64}", Id = data.BrukerId });


            return Ok(res.Equals(1));
        }
    }
}
