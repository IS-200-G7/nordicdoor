using Microsoft.AspNetCore.Mvc;
using PDSA_System.Shared.Models;
using PDSA_System.Server.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;

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


        /** GetAllBrukere
         * @return - OkObjectResult
         * 
         * Hente ut alle brukere fra databasen
         */
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<Bruker>>> GetAllBrukere()
        {
            // Lag en kobling til databasen
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukere = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker");

            return Ok(brukere);
        }


        /** GetBruker
         * @param - int AnsattNr
         * @return - OkObjectResult
         * 
         * Hente en spesifikk bruker basert på AnsattNr
         */
        [HttpGet("/api/[controller]/{AnsattNr}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Bruker>> GetBruker(int AnsattNr)
        {
            // Lag en kobling til databasen
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var bruker = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker WHERE AnsattNr = @id", new { id = AnsattNr });

            var valgtBruker = bruker.First();
            //Gjør at passord ikke sendes og passordhash ikke blir vist i profilpage
            valgtBruker.PassordHash = "";
            return Ok(valgtBruker);
        }


        /** OppdaterTeam
         * @param - int AnsattNr
         * @return - OkObjectResult
         * 
         * Sjekker om bruker har admin eller teamleder rolle, for å så legge til bruker i et Team
         */
        [HttpPost("/api/[controller]/addBrukerToTeam/")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> OppdaterTeam(TeamMedlemskap teammedlemskap)
        {
            // Lag en kobling til databasen
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync("INSERT INTO TeamMedlemskap(TeamId, AnsattNr) Values (@TeamId, @AnsattNr)", teammedlemskap);

            return Ok(res.Equals(1));
        }


        /** CreateBruker
         * @param - Bruker bruker
         * @return - OkObjectResult
         * 
         * Lag en ny bruker
         */
        [HttpPost("/api/[controller]/createBruker/")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Bruker>> CreateBruker(Bruker bruker)
        {
            // Lag en kobling til databasen
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync(
                "INSERT INTO Bruker(AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, Opprettet, LederId) VALUES(@AnsattNr, @Fornavn, @Etternavn, @Email, @PassordHash, @Rolle, @Opprettet, @LederId)",
                bruker);

            return Ok(res.Equals(1));
        }


        /** UpdateBruker
         * @param - Bruker bruker
         * @return - OkObjectResult
         * 
         * Oppdater infoen til en bruker
         */
        [HttpPut("/api/[Controller]/admin/UpdateBruker")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> UpdateBruker(Bruker bruker)
        {
            // Lag en kobling til databasen
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync(
               "UPDATE Bruker SET Fornavn = @Fornavn, Etternavn = @Etternavn, Email = @Email, LederId = @LederId, Rolle = @Rolle WHERE AnsattNr = @AnsattNr",
               bruker);

            return Ok(res.Equals(1));
        }


        /** DeleteBruker
         * @param - int AnsattNr
         * @return - OkObjectResult
         * 
         * Slett en bruker basert på AnsattNr
         */
        [HttpDelete("/api/[controller]/admin/DeleteBruker/{AnsattNr}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteBruker(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync(
                "DELETE FROM Bruker WHERE AnsattNr = @Id", new { id = AnsattNr });

            return Ok(res.Equals(1));
        }

        /** ByttPassord
         * @param - ByttPassord data
         * @return - OkObjectResult
         * 
         * Byttpassord fra form data som er brukerId og selve passordet
         */
        [HttpPost("/api/[controller]/byttPassord/")]
        [Authorize(Roles = "admin")]
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
