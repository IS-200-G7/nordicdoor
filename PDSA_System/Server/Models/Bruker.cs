
namespace PDSA_System.Client.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }

        public string Fornavn { get; set; }
        
        public string Etternavn { get; set; }

        public string Email { get; set; }

        public string PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string Rolle { get; set; }

        // public List<Lag> Lag{ get; set; }

        /*
         Er List den beste datastrukturen? Kanskje HashMap <K,V>.
         */


        public Bruker()
        {
            
        }



    }
}