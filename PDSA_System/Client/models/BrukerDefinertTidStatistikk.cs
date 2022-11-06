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

    }
}

