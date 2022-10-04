
namespace PDSA_System.Server.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }

        public string Fornavn { get; set; }
        
        public string Etternavn { get; set; }

        public string Email { get; set; }

        public string PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string Rolle { get; set; }

        public DateTime Opprettet { get; set; }


        // public List<Lag> Lag{ get; set; }

        //Dersom man bruker dapper må man ha en default/tom ctor("param")
        /*
         Er List den beste datastrukturen? Kanskje HashMap <K,V>.
         */

        public Bruker()
        {
            BrukerId = 0;
            Fornavn = "";
            Etternavn = "";
            Email = "";
            PassordHash = "";
            Rolle = "";
        }

    }
}