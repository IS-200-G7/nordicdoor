
namespace PDSA_System.Client.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }
        public string Navn { get; set; }

        public string Email { get; set; }

        private int PassordHash { get; set; } //Trenger rettninglinsjer her.

        public Bruker()
        {
            
        }



    }
}