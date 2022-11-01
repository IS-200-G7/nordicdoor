namespace PDSA_System.Shared.Models
{
    public class Bruker
    {
        public int AnsattNr { get; set; }

        public string? Fornavn { get; set; }

        public string? Etternavn { get; set; }

        public string? Email { get; set; }

        public string? PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string? Rolle { get; set; }

        public int? LederId { get; set; }

        public DateTime Opprettet { get; set; }

        // Create a dictionary that stores the different team the user is a part of.

        // public Dictionary<int, Team> Teams { get; set; }

        //Dersom man bruker dapper må man ha en default/tom ctor("param")

        // Er List den beste datastrukturen? Kanskje HashMap <K,V>.
    }
}
