
namespace PDSA_System.Server.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }

        public string Fornavn { get; set; }

        public string EtterNavn { get; set; }

        public string Email { get; set; }

        private string PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string Rolle { get; set; }

        // public List<Lag> Lag{ get; set; }

        /*
         Er List den beste datastrukturen? Kanskje HashMap <K,V>.
         */

        // Constructor for Bruker
        public Bruker(string forNavn, string etterNavn, string email, string rolle)
        {
            this.Fornavn = forNavn;
            this.EtterNavn = etterNavn;
            this.Email = email;
            this.PassordHash = ""; //Hente passord fra authController.
            this.Rolle = rolle;
            
        }



    }
}