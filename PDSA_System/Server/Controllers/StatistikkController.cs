using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;


namespace PDSA_System.Server.Controllers
{
    [Route("/api/[controller]")]
    public class StatistikkController : Controller
    {
        private readonly IConfiguration _configuration;

        public StatistikkController (IConfiguration configuration)
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
                new { AnsattNr = AnsattNr});

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
                new {AnsattNr = AnsattNr, Status = Status});

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

    }
}

