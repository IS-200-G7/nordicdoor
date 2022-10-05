namespace PDSA_System.Server.Models
{
    public class Forslag
    {
        public int ForfatterId { get; set; }
        public int GruppeId { get; set; }

        public string Emne { get; set; }

        public string Beskrivelse { get; set; }

        public byte[] Bilde { get; set; }

        public int Status { get; set; }

        public DateTime Tidspunkt { get; set; }

        public Forslag()
        {
        }
    }
}

/*

   ForslagsId INTEGER NOT NULL AUTO_INCREMENT,
                ForfatterId INTEGER NOT NULL,
                GruppeId INTEGER NOT NULL,
                Emne VARCHAR(150) NOT NULL,
                Beskrivelse VARCHAR(2000) NOT NULL,
                Bilde MEDIUMBLOB,
                Status INTEGER DEFAULT 1 NOT NULL,
                Tidspunkt DATE,

*/
