using Microsoft.AspNetCore.Mvc;
using PDSA_System.Shared.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Routing;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;

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


        /** GetAllTeams
         * @return - OkObjectResult
         * 
         * Hent ut alle teams i databasen
         */
        [HttpGet]
        [Authorize(Roles = "admin")]
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


        /** GetTeam
         * @param - int TeamId
         * @return - OkObjectResult
         * 
         * Hent ut et spesifikk team basert på TeamId
         */
        [HttpGet("/api/[controller]/{TeamId}")]
        [Authorize(Roles = "teamleder,admin")]
        public async Task<ActionResult<Team>> GetTeam(int TeamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;

            var team = await conn.QueryAsync<Team>("SELECT * FROM Team WHERE TeamId = @id", new { id = TeamId });

            return Ok(team.First());
        }


        /** CreateTeam
         * @param - Team team
         * @return - OkObjectResult
         * 
         * Lag et nytt team
         */
        [HttpPost("/api/[controller]/OpprettTeam/")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> CreateTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            // Await conn.ExecudeAsync betyr at vi venter på at denne linjen skal bli ferdig før vi fortsetter med neste linje
            var res = await conn.ExecuteAsync("INSERT INTO Team(TeamLederId, Navn, AvdelingId) VALUES (@TeamLederId, @Navn, @AvdelingId)", team);

            // Returner statuskode 200 og teamet som ble lagt til i database
            return Ok(res.Equals(1));
        }


        /** EditTeam
         * @param - Team team
         * @return - OkObjectResult
         * 
         * Oppdater infoen til et team
         */
        [HttpPut]
        [Authorize(Roles = "teamleder")]
        public async Task<ActionResult<Team>> EditTeam(Team team)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;
            await conn.ExecuteAsync("UPDATE Team SET TeamLederId = @TeamLederId, Navn = @Navn, AvdelingId = @AvdelingId WHERE TeamId = @TeamId", team);

            return Ok(await GetTeam(team.TeamId));
        }


        /** DeleteTeam
         * @param - int TeamId
         * @return - OkObjectResult
         * 
         * Slett et team basert på TeamID
         */
        [HttpDelete("/api/[controller]/{TeamId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> DeleteTeam(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync("DELETE FROM Team WHERE TeamId = @id", new { id = TeamId });

            return Ok(res.Equals(1));
        }


        /** GetUsersFromTeam
         * @param - int TeamId
         * @return - OkObjectResult
         * 
         * Hent alle medlemmene tilknyttet et spesefikt team
         */
        [HttpGet("/api/[controller]/GetBrukere")]
        [Authorize(Roles = "teamleder")]
        public async Task<ActionResult<List<TeamMedlemskap>>> GetUsersFromTeam(int TeamId)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;
            // Hente ut teammedlemskap
            var medlemskap = await conn.QueryAsync<TeamMedlemskap>("SELECT * FROM TeamMedlemskap WHERE TeamId = @id",
                new { id = TeamId });

            // Returner en statuskode 200 og teamedlemskapet som ble hentet fra databasen
            return Ok(medlemskap);
        }


        /** GetUsersFromTeamDetail
         * @param - int TeamId
         * @return - OkObjectResult
         * 
         * Hent brukere tilknuttet til et spesifikt team
         */
        [HttpGet("/api/[controller]/GetBrukereDetail/{ansattNr}")]
        [Authorize(Roles = "admin,teamleder")]
        public async Task<ActionResult<List<TeamMedlemskap>>> GetUsersFromTeamDetail(int ansattNr)
        {
            var conneString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(conneString).Connection;
            // denne linjen henter ut teammedlemskap
            var medlemskap = await conn.QueryAsync<TeamMedlemskap>("SELECT  t.teamId, t.Navn, tm.AnsattNr, b.Fornavn, b.Etternavn, b.Email FROM TeamMedlemskap tm INNER JOIN Bruker b  ON tm.AnsattNr = b.AnsattNr JOIN Team t ON t.teamId = tm.teamid WHERE tm.teamid = (Select tm.TeamId from TeamMedlemskap as tm, Bruker as b where b.AnsattNr = @id and tm.AnsattNr = @id and b.Rolle = 'teamleder' order by tm.TeamId desc limit 1)",
                new { id = ansattNr });
            // denne returnerer en statuskode 200 og teamedlemskapet som ble hentet fra databasen
            return Ok(medlemskap);
        }


        /** DeleteUsersFromTeam
         * @param - int AnsattNr
         * @param - int TeamId
         * @return - OkObjectResult
         * 
         * Slett bruker fra et team basert på AnsattNr og TeamId
         */
        [HttpDelete("/api/[controller]/DeleteBrukere")]
        [Authorize(Roles = "teamleder,admin")]
        public async Task<ActionResult<List<Team>>> DeleteUsersFromTeam(int AnsattNr, int TeamId)
        {
            var connString = _configuration.GetValue<String>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var res = await conn.ExecuteAsync("DELETE FROM TeamMedlemskap WHERE AnsattNr = @id AND TeamId = @TeamId",
                new { id = AnsattNr, TeamId = TeamId });

            return Ok(res.Equals(1));
        }
    }
}
