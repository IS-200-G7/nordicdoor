namespace PDSA_System.Client.Models
{
    public class Admin : Bruker
    {
        /*
        Hvilke andre atributter trenger en admin.

        Rolle

        */

        private Bruker LeggTilNyBruker()
        {
            return new Bruker();
        }
    }
}