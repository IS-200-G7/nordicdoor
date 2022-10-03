using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDSA_System.Server.Models;
using Dapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDSA_System.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrukerController : Controller
    {

        private readonly IConfiguration _configuration;

        public BrukerController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
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

            var brukere = await conn.QueryAsync<Bruker>("select * from Bruker");

            return Ok(brukere);
        }


        /**
         * Henter en spesifikk bruker iforhold til hvilken route man er på.
         * URL --> NordicDoor/Bruker/1 vil hente ut bruker med brukerId 1.
         * Returnerer statuskode 200 dersom det ikke oppstår feil.
        */
        [HttpGet("{brukerId}")]
        public async Task<ActionResult<List<Bruker>>> GetBruker (int brukerId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            var brukere = await conn.QueryAsync<Bruker>("SELECT * FROM Bruker WHERE BrukerId = @id",
                new { id = brukerId});

            return Ok(brukere);
        }


        /*
        
         */
        [HttpPost]
        public async Task<ActionResult<List<Bruker>>> CreateBruker(Bruker bruker)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            await conn.ExecuteAsync(
                "insert into Bruker(ForNavn, EtterNavn, Email, Rolle, PassordHash) values (@ForNavn, @EtterNavn, @Email, @Rolle, @PassordHash))", bruker);

            return Ok(await GetBruker(bruker.BrukerId));
        }



    }
}

