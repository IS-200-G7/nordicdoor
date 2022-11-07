using System;
namespace PDSA_System.Client.Models
{
    public class TeamStatistikk
    {
        public int TeamId { get; set; }
        public string? Status { get; set; }
        public int Count { get; set; }

        public void Reset(){
            this.TeamId = 0;
            this.Status = null;
            this.Count = 0;
        }
    }
}

