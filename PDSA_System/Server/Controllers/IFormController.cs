using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using PDSA_System.Shared.Models;
using System.IO;

namespace PDSA_System.Server.Controllers
{
    public class IFormController : Controller
    {
        private readonly IConfiguration _configuration;
        public IFormController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //Metode for å oppdatere Bilde-kolonne i forslag
        [HttpPost("/api/[controller]/UploadImage/")]
        public async Task<ActionResult<bool>> UploadImage(IFormFile imageFile, int forslagId)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            using var conn = new DbHelper(connString).Connection;

            string filePath = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(filePath))
            {
                await imageFile.CopyToAsync(stream);
            }
            // Converts image file into byte[]
            byte[] imageData = await System.IO.File.ReadAllBytesAsync(filePath);

            var parameters = new DynamicParameters();
            parameters.Add("@Bilde", imageData, DbType.Binary);
            parameters.Add("@Id", forslagId);

            var res = await conn.ExecuteAsync("UPDATE Forslag SET Bilde = @Bilde WHERE ForslagId = @Id", parameters);

            return Ok(res.Equals(1));
        }


    }
}
