using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDSA_System.Server.Controllers
{
    [Route("Bruker/[controller]")]
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

        [HttpPost]
        public void endreNavn(string navn)
        {

        }

    }
}

