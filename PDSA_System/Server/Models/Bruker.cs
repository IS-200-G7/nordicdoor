
namespace PDSA_System.Server.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }

        public string ForNavn { get; set; }

        public string EtterNavn { get; set; }

        public string Email { get; set; }

        private string PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string Rolle { get; set; }

        public DateTime Opprettet { get; set; }


        // public List<Lag> Lag{ get; set; }

        //Dersom man bruker dapper må man ha en default/tom ctor("param")
    }
}