using Microsoft.AspNetCore.Mvc;
using PDSA_System.Shared.Models;
using Dapper;

namespace PDSA_System.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly IConfiguration _configuration;

        public TeamController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //Dette er en GET request som henter ut alle lagene i databasen.
        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            // denne linjen henter ut connectionstringen fra appsettings.json
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            // denne linjen oppretter en ny connection til databasen
            using var conn = new DbHelper(connString).Connection;
            // denne linjen er hvor vi foretar forespørsler.
            var teams = await conn.QueryAsync<Team>("SELECT * FROM Team");
            // denne returnerer en statuskode 200 og alle teamene som ble hentet fra databasen 
            return Ok(teams);
        }


        /*
        Metoden Henter ut et spesifikk lag med param(TeamId)
        */
        [HttpGet("/api/[controller]/{TeamId}")]
        public async Task<ActionResult<List<Team>>> GetTeam(int TeamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;

            var teams = await conn.QueryAsync<Team>("SELECT * FROM Team WHERE TeamId = @id", new { id = TeamId });

            return Ok(teams);
        }


        /*
        Denne Metoden lager en Tuppel/Team i DB.
        */

        [HttpPost("/api/[controller]/OpprettTeam/")]
        // denne linjen sier at denne metoden skal kjøres når det kommer en POST request
        public async Task<ActionResult<List<Team>>> CreateTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;
            await conn.ExecuteAsync("INSERT INTO Team(TeamLederId, Navn, AvdelingId) VALUES (@TeamLederId, @Navn, @AvdelingId)", team);

            // Await conn.ExecudeAsync betyr at vi venter på at denne linjen skal bli ferdig før vi fortsetter med neste linje.

            return Ok(team); // denne linjen returnerer statuskode 200 og teamet som ble lagt til i database
        }


        /* EditTeam
        * Denne metoden oppdaterer et Team.
        */
        [HttpPut("/api/[controller]/updateteam/{TeamId}")]
        public async Task<ActionResult<List<Team>>> EditTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;
            await conn.ExecuteAsync("UPDATE Team SET TeamLederId = @TeamLederId, Navn = @Navn, AvdelingId = @AvdelingId WHERE TeamId = @TeamId",
                team);


            return Ok(await GetTeam(team.TeamId));
        }

        /* DeleteTeam
        * Denne metoden sletter Teams fra tabellen Team som er like teamid parameteret.
        */
        [HttpDelete("/api/[controller]/{TeamId}")]
        public async Task<ActionResult<List<Team>>> DeleteTeam(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("DELETE FROM Team WHERE TeamId = @id", new { id = TeamId });

            return Ok(TeamId);
        }

        /* GetBrukere
         * Denne henter alle medlemmene tilknyttet et spesefikt team
         */
        [HttpGet("/api/[controller]/GetBrukere")]
        public async Task<ActionResult<List<Team>>> GetUsersFromTeam(int TeamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;
            // denne linjen henter ut teammedlemskap
            var Brukere = await conn.QueryAsync<TeamMedlemskap>("SELECT * FROM TeamMedlemskap WHERE TeamId = @id",
                new { id = TeamId });

            // denne returnerer en statuskode 200 og temedlemskapet som ble hentet fra databasen
            return Ok(Brukere);
        }


        /* DeleteBrukere
         * Denne sletter brukere fra et team ved å slette deres teamedlemskap
        */
        [HttpDelete("/api/[controller]/DeleteBrukere")]
        public async Task<ActionResult<List<Team>>> DeleteUsersFromTeam(int AnsattNr, int TeamId)
        {
            var connString = _configuration.GetValue<String>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("DELETE FROM TeamMedlemskap WHERE AnsattNr = @id AND TeamId = @TeamId",
                new { id = AnsattNr, TeamId = TeamId });

            return Ok(AnsattNr);
        }
    }
}
