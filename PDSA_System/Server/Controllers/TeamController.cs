using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;

namespace PDSA_System.Server.Controllers
{

    [Route("/api/[controller]")]
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
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");        // denne linjen henter ut connectionstringen fra appsettings.json
            using var conn = new DbHelper(connString).Connection;                                           // denne linjen oppretter en ny connection til databasen

            var teams = await conn.QueryAsync<Team>("SELECT * FROM Team");                                  // denne linjen er hvor vi foretar forespørsler.

            return Ok(teams);                                                                               // denne returnerer en statuskode 200 og alle teamene som ble hentet fra databasen 
        }

        
        /*
        Metoden Henter ut et spesifikk lag med param(teamId)
        */
        [HttpGet("/api/[controller]/{teamId}")]

        public async Task<ActionResult<List<Team>>> GetTeam(int teamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;

            var teams = await conn.QueryAsync<Team>("SELECT * FROM Team WHERE TeamId = @id", new { id = teamId });

            return Ok(teams);
        }


        /*
        Denne Metoden lager en Tuppel/Team i DB.
        */
        [HttpPost]                                                                                                  // denne linjen sier at denne metoden skal kjøres når det kommer en POST request
        public async Task<ActionResult<List<Team>>> CreateTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");                 // denne linjen henter ut connectionstringen fra appsettings.json
            using var conn = new DbHelper(connString).Connection;                                                   // denne linjen oppretter en ny connection til databasen

            await conn.ExecuteAsync("INSERT INTO Team (Navn, AvdelingsId) VALUES (@Navn, @AvdelingsId)", team);     // denne linjen legger til et nytt team i databasen

            // Await conn.ExecudeAsync betyr at vi venter på at denne linjen skal bli ferdig før vi fortsetter med neste linje.

            return Ok(await GetTeam(team.teamId)); // denne linjen returnerer statuskode 200 og teamet som ble lagt til i databasen 
        }

        /* EditTeam
        * Denne metoden oppdaterer et Team.
        */ 
        [HttpPut]
        public async Task<ActionResult<List<Team>>> EditTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection; 

            await conn.ExecuteAsync("UPDATE Team SET Navn = @Navn, AvdelingsId = @AvdelingsId WHERE TeamId = @TeamId", team); 

        

            return Ok(await GetTeam(team.teamId)); 
        }
        
        /* DeleteTeam
        * Denne metoden sletter Teams fra tabellen Team som er like teamid parameteret.
        */
        [HttpDelete("/api/[controller]/{teamId}")]

        public async Task<ActionResult<List<Team>>> DeleteTeam(int teamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("DELETE FROM Team WHERE TeamId = @id", new { id = teamId });

            return Ok(teamId);
        }
        
        /* GetBrukere
         * Denne henter alle medlemmene tilknyttet et spesefikt team
         */
        [HttpGet("/api/[controller]/GetBrukere")] // denne linjen sier at denne metoden skal kjøres

        public async Task<ActionResult<List<Team>>> GetUsersFromTeam(int teamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection"); // denne linjen henter ut connectionstringen fra appsettings.json
            using var conn = new DbHelper(conneString).Connection; // denne linjen oppretter en ny connection til databasen

            var Brukere = await conn.QueryAsync<TeamMedlemskap>("SELECT * FROM teammedlemskap WHERE TeamId = @id", new { id = teamId }); // denne linjen henter ut teammedlemskap

            return Ok(Brukere); // denne returnerer en statuskode 200 og temedlemskapet som ble hentet fra databasen
        }



        /* DeleteBrukere
         * Denne sletter brukere fra et team ved å slette deres teamedlemskap
        */
        [HttpDelete("/api/[controller]/DeleteBrukere")]
        public async Task<ActionResult<List<Team>>> DeleteUsersFromTeam(int BrukerId, int TeamId)
        {
            var connString = _configuration.GetValue<String>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync("DELETE FROM teammedlemskap WHERE BrukerId = @id AND TeamId = @TeamId", new { id = BrukerId, TeamId = TeamId });

            return Ok(BrukerId);
        }


    }

}
