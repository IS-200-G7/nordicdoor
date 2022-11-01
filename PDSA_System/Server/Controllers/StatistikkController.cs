using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using PDSA_System.Shared.Models;
using PDSA_System.Server.Models;
using Google.Protobuf.WellKnownTypes;

namespace PDSA_System.Server.Controllers
{
    [Route("/api/[controller]")]
    public class StatistikkController : Controller
    {
        private readonly IConfiguration _configuration;

        public StatistikkController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        /** GetBrukerStatistikk
         * @param - int AnsattNr, string Status
         * @return - Task
         *
         * Henter hvor mange forslag en bruker har laget
         */
        [HttpGet("/api/[controller]/{AnsattNr}")]
        public async Task<ActionResult<Statistikk>> GetBrukerForslagStatistikk(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Statistikk>("SELECT F.ForfatterId, F.TeamId, B.Fornavn, B.Etternavn, COUNT(*) AS Count FROM Forslag AS F, Bruker AS B WHERE F.ForfatterId = B.AnsattNr and F.ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk.First());
        }


        /** GetBrukerForslagStatistikk
         * @param - int AnsattNr, string Status
         * @return - Task
         *
         * Henter hvor mange forslag en bruker har laget, filtrert med status
         */
        [HttpGet("/api/[controller]/{AnsattNr}/{Status}")]
        public async Task<ActionResult<Statistikk>> GetBrukerForslagStatusStatistikk(int AnsattNr, string Status)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Statistikk>("SELECT F.ForfatterId, F.TeamId, B.Fornavn, B.Etternavn, F.Status, COUNT(*) AS Count FROM Forslag AS F, Bruker AS B WHERE F.ForfatterId = B.AnsattNr AND F.ForfatterId = @AnsattNr AND Status = @Status",
                new { AnsattNr = AnsattNr, Status = Status });

            return Ok(brukerStatistikk.First());
        }



        /** GetTeamStatistikk
         * @param - int TeamId, string Status
         * @return - Task
         *
         * Henter hvor mange forslag en bruker har laget
         */
        [HttpGet("/api/[controller]/Team/{TeamId}")]
        public async Task<ActionResult<Statistikk>> GetTeamForslagStatistikk(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, COUNT(*) AS Count FROM Forslag WHERE TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(teamStatistikk.First());
        }


        /** GetTeamForslagStatusStatistikk
        * @param - int TeamId, string Status
        * @return - Task
        *
        * Henter hvor mange forslag et team har laget, filtrert med status
        */
        [HttpGet("/api/[controller]/Team/{TeamId}/{Status}")]
        public async Task<ActionResult<Statistikk>> GetTeamForslagStatusStatistikk(int TeamId, string Status)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, Status, COUNT(*) AS Count FROM Forslag WHERE TeamId = @TeamId AND Status = @Status",
                new { TeamId = TeamId, Status = Status });

            return Ok(teamStatistikk.First());

        }


        /** GetBrukerUkentligAktivitet
         * @param - int BrukerId
         * @return - Task
         *
         * Henter alle forslagene til en spesifikk bruker innen en uke (7 dager).
         */
        [HttpGet("/api/[controller]/Bruker/{AnsattNr}/Uke")]
        public async Task<ActionResult<Statistikk>> GetBrukerUkentligAktivitet(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;
            var brukerStatistikk = await conn.QueryAsync<Statistikk>("SELECT F.ForfatterId, F.TeamId, B.Fornavn, B.Etternavn, COUNT(*) AS Count FROM Forslag AS F, Bruker AS B WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 7 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 7 DAY)) <= 7 AND F.ForfatterId = B.AnsattNr And F.ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk.First());
        }


        /** GetBrukerMånedligAktivitet
         * @param - int BrukerId
         * @return - Task
         *
         * Henter alle forslagene til en spesifikk bruker innen en måned (30 dager).
         */
        [HttpGet("/api/[controller]/Bruker/{AnsattNr}/Måned")]
        public async Task<ActionResult<Statistikk>> GetBrukerMånedligAktivitet(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Statistikk>("SELECT F.ForfatterId, F.TeamId, B.Fornavn, B.Etternavn, COUNT(*) AS Count FROM Forslag AS F, Bruker AS B WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 30 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 30 DAY)) <= 30 AND F.ForfatterId = B.AnsattNr And F.ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk.First());
        }


        /** GetTeamsUkentligAktivitet
         * @return - Task
         *
         * Henter forsalgene til hvert team som er laget denne uken, gruppert etter TeamId og sortert i synkende rekkefølge.
         */
        [HttpGet("/api/[controller]/Teams/Uke")]
        public async Task<ActionResult<List<Statistikk>>> GetTeamsUkentligAktivitet()
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, COUNT(*) AS Count FROM Forslag AS F WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -7 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -7 DAY)) <= 7 GROUP BY TeamId ORDER BY Count DESC");

            return Ok(teamStatistikk);
        }


        /** GetTeamUkentligAktivitet
         * @param - int BrukerId
         * @return - Task
         *
         * Henter alle forslagene til en spesifikk Team innen en uke (7 dager).
         */
        [HttpGet("/api/[controller]/Team/{TeamId}/Uke")]
        public async Task<ActionResult<Statistikk>> GetTeamUkentligAktivitet(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, COUNT(*) AS Count FROM Forslag AS F WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -7 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 7 DAY)) <= 7 AND TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(teamStatistikk.First());
        }


        /** GetTeamsMånedligAktivitet
         * @return - Task
         *
         * Henter forsalgene til hvert team gruppert etter TeamId og sortert i synkende rekkefølge.
         */
        [HttpGet("/api/[controller]/Teams/Måned")]
        public async Task<ActionResult<List<Statistikk>>> GetTeamsMånedligAktivitet()
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, COUNT(*) AS Count FROM Forslag AS F WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -30 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -30 DAY)) <= 30 GROUP BY TeamId ORDER BY Count DESC");

            return Ok(teamStatistikk);
        }

        /** GetTeamMånedligAktivitet
         * @param - int BrukerId
         * @return - Task
         *
         * Henter alle forslagene til en spesifikk Team innen en måned (30 dager).
         */
        [HttpGet("/api/[controller]/Team/{TeamId}/Måned")]
        public async Task<ActionResult<Statistikk>> GetTeamMånedligAktivitet(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT TeamId, COUNT(*) AS Count FROM Forslag AS F WHERE DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -30 DAY)) > 0 AND DATEDIFF(F.Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL - 30 DAY)) <= 30 AND TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(teamStatistikk.First());
        }



        /** GetTeamStatistikkBetween
        * @param - DateTime time01, DateTime time02, int TeamId
        * @return - Task
        *
        * Henter alle forslagene til et spesifikk Team innenfor en brukerdefinert periode. Imellom @time01 og @time@2.
        */
        [HttpGet("/api/[controller]/Team/{TeamId}/Between")]
        public async Task<ActionResult<Statistikk>> GetTeamStatistikkBetween(DateTime time01, DateTime time02, int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Statistikk>("SELECT Count(*) AS Count, TeamId FROM Forslag WHERE Opprettet BETWEEN @time01 AND @time02 AND TeamId = @TeamId",
                new { time01 = time01, time02 = time02, TeamId = TeamId });

            return Ok(teamStatistikk.First());
        }


        /** GetBrukerStatistikkBetween
         * @param - DateTime time01, DateTime time02, int ForfatterId
         * @return - Task
         *
         * Henter alle forslagene til en spesifikk Bruker innenfor en brukerdefinert periode. Imellom @time01 og @time@2.
         */
        [HttpGet("/api/[controller]/Bruker/{ForfatterId}/Between")]
        public async Task<ActionResult<Statistikk>> GetBrukerStatistikkBetween(DateTime time01, DateTime time02, int ForfatterId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Statistikk>("SELECT Count(*) AS Count, ForfatterId FROM Forslag WHERE Opprettet BETWEEN @time01 AND @time02 AND ForfatterId = @ForfatterId",
                new { time01 = time01, time02 = time02, ForfatterId = ForfatterId });

            return Ok(brukerStatistikk.First());
        }

        /** GetStatistikkBetween
        * @param - DateTime time01, DateTime time02
        * @return - Task
        *
        * Henter alle forslagene innenfor en brukerdefinert periode. Imellom @time01 og @time@2.
        */
        [HttpGet("/api/[controller]/Between")]
        public async Task<ActionResult<Statistikk>> GetStatistikkBetween(DateTime time01, DateTime time02)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var statistikk = await conn.QueryAsync<Statistikk>("SELECT Count(*) AS Count FROM Forslag WHERE Opprettet BETWEEN @time01 AND @time02",
                new { time01 = time01, time02 = time02 });

            return Ok(statistikk.First());
        }

    }
}

