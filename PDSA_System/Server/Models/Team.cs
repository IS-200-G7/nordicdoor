namespace PDSA_System.Server.Models
{
     public class Team
    {

        public int TeamId { get; set; }

        public string? Navn { get; set; }

        public int AvdelingsId { get; set; }

        // Create something that stores the different users that are a part of the team.
       // public Dictionary<int, Bruker> Brukere { get; set; } // Denne linjen sier at vi skal ha en dictionary som skal lagre brukere som er en del av teamet.



    }
}
