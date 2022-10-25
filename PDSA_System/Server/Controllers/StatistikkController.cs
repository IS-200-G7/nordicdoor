using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using PDSA_System.Shared.Models;

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
        public async Task<ActionResult<List<Object>>> GetBrukerForslagStatistikk(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT COUNT(*) FROM Forslag WHERE ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk);
        }


        /** GetBrukerForslagStatistikk
         * @param - int AnsattNr, string Status
         * @return - Task
         * 
         * Henter hvor mange forslag en bruker har laget, filtrert med status
         */
        [HttpGet("/api/[controller]/{AnsattNr}/{Status}")]
        public async Task<ActionResult<List<Object>>> GetBrukerForslagStatusStatistikk(int AnsattNr, string Status)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT COUNT(*) FROM Forslag WHERE ForfatterId = @AnsattNr AND Status = @Status",
                new { AnsattNr = AnsattNr, Status = Status });

            return Ok(brukerStatistikk);
        }



        /** GetTeamStatistikk
         * @param - int TeamId, string Status
         * @return - Task
         * 
         * Henter hvor mange forslag en bruker har laget
         */
        [HttpGet("/api/[controller]/Team/{TeamId}")]
        public async Task<ActionResult<List<Object>>> GetTeamForslagStatistikk(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT COUNT(*) FROM Forslag WHERE TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(brukerStatistikk);
        }


        /** GetTeamForslagStatusStatistikk
        * @param - int TeamId, string Status
        * @return - Task
        * 
        * Henter hvor mange forslag et team har laget, filtrert med status
        */
        [HttpGet("/api/[controller]/Team/{TeamId}/{Status}")]
        public async Task<ActionResult<List<Object>>> GetTeamForslagStatusStatistikk(int TeamId, string Status)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT COUNT(*) FROM Forslag WHERE TeamId = @TeamId AND Status = @Status",
                new { TeamId = TeamId, Status = Status });

            return Ok(brukerStatistikk);

        }



        //SELECT Count(*) FROM Forslag WHERE DATEDIFF(Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL -7 DAY))<=7 AND ForfatterId = 2;

        /** GetBrukerUkentligAktivitet
         * @param - int BrukerId
         * @return - Task
         * 
         * Henter alle forslagene til en spesifikk bruker innen en uke (7 dager).
         */
        [HttpGet("/api/[controller]/Bruker/{AnsattNr}/Uke")]
        public async Task<ActionResult<List<Object>>> GetBrukerUkentligAktivitet(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT Count(*) FROM Forslag WHERE DATEDIFF(Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -7 DAY)) <= 7 AND ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk);
        }


        /** GetBrukerMånedligAktivitet
         * @param - int BrukerId
         * @return - Task
         * 
         * Henter alle forslagene til en spesifikk bruker innen en måned (30 dager).
         */
        [HttpGet("/api/[controller]/Bruker/{AnsattNr}/Måned")]
        public async Task<ActionResult<List<Object>>> GetBrukerMånedligAktivitet(int AnsattNr)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukerStatistikk = await conn.QueryAsync<Object>("SELECT Count(*) FROM Forslag WHERE DATEDIFF(Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -30 DAY)) <= 30 AND ForfatterId = @AnsattNr",
                new { AnsattNr = AnsattNr });

            return Ok(brukerStatistikk);
        }



        /** GetTeamUkentligAktivitet
         * @param - int BrukerId
         * @return - Task
         * 
         * Henter alle forslagene til en spesifikk Team innen en uke (7 dager).
         */
        [HttpGet("/api/[controller]/Team/{TeamId}/Uke")]
        public async Task<ActionResult<List<Object>>> GetTeamUkentligAktivitet(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Object>("SELECT Count(*) FROM Forslag WHERE DATEDIFF(Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  -7 DAY)) <= 7 AND TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(teamStatistikk);
        }


        /** GetTeamMånedligAktivitet
         * @param - int BrukerId
         * @return - Task
         * 
         * Henter alle forslagene til en spesifikk Team innen en måned (30 dager).
         */
        [HttpGet("/api/[controller]/Team/{TeamId}/Måned")]
        public async Task<ActionResult<List<Object>>> GetTeamMånedligAktivitet(int TeamId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var teamStatistikk = await conn.QueryAsync<Object>("SELECT Count(*) FROM Forslag WHERE DATEDIFF(Opprettet, ADDDATE(CURRENT_TIMESTAMP(), INTERVAL  30 DAY)) <= 30 AND TeamId = @TeamId",
                new { TeamId = TeamId });

            return Ok(teamStatistikk);
        }
    }
}

