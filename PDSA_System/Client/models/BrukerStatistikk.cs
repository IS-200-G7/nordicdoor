using System;
namespace PDSA_System.Client.Models
{
    public class BrukerStatistikk
    {
        public int ForfatterId { get; set; }

        public int TeamId  { get; set; }

        public string? Fornavn { get; set; }

        public string? Etternavn { get; set; }

        public string? Status { get; set; }

        public int Count { get; set; }

       
    }
}

