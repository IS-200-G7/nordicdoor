using System.ComponentModel.DataAnnotations;

namespace PDSA_System.Shared.Models
{
    public class Bruker
    {
        public int AnsattNr { get; set; }

        public string? Fornavn { get; set; }

        public string? Etternavn { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? Email { get; set; }

        public string? PassordHash { get; set; } = "";

        public string? Rolle { get; set; }

        public int? LederId { get; set; }

        public DateTime Opprettet { get; set; } = DateTime.UtcNow;

    }
}
