/* TeamMedlemskap
* Denne modellen representerer koblingsentiteten mellom Team og Bruker.
* Dette er en mange til mange kobling hvor en bruker kan være medlem av flere Teams.
*/

namespace PDSA_System.Shared.Models
{
    public class TeamMedlemskap
    {
        public int TeamId { get; set; }
        public int AnsattNr { get; set; }
        public string? Navn { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        public string? Email { get; set; }

    }
}
