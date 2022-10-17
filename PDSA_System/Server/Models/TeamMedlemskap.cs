/* TeamMedlemskap
* Denne modellen representerer koblingsentiteten mellom Team og Bruker.
* Dette er en mange til mange kobling hvor en bruker kan være medlem av flere Teams.
*/
namespace PDSA_System.Server.Models
{
    
    public class TeamMedlemskap
    {
        public int TeamId { get; set; }    

        public int AnsattNr { get; set; }
    }
}
