using System;
namespace PDSA_System.Client.Models
{
    public class BrukerDefinertTidStatistikk
    {
        public int AnsattNr { get; set; }

        public int TeamId { get; set; }

        public DateTime DatoFra { get; set; } = DateTime.Today;

        public DateTime DatoTil { get; set; } = DateTime.Today;

        public int Count { get; set; }

        public void Reset(){
            this.AnsattNr = 0;
            this.TeamId = 0;
            this.DatoFra = DateTime.Today;
            this.DatoTil = DateTime.Today;
            this.Count = 0;

        }
    }
}

