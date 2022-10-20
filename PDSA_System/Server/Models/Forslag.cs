using System.Reflection.Metadata;

namespace PDSA_System.Server.Models
{
    public class Forslag
    {
        public int ForslagId { get; set; }

        public int ForfatterId { get; set; }

        public int TeamId { get; set; }

        public string Emne { get; set; } = "";

        public string Beskrivelse { get; set; } = "";

        public byte[]? Bilde { get; set; }

        public string Status { get; set; }

        public DateTime Opprettet { get; set; }

        public DateTime SistOppdatert { get; set; }

        public DateTime Frist { get; set; }

        public string Kategori { get; set; } = "";

        // Kategori er egentlig en definert liste.
        // Kan sette deafultverdi for en av de f.eks.
    }
}


