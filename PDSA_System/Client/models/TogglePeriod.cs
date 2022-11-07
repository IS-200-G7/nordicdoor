using System;
namespace PDSA_System.Client.Models
{
    public class TogglePeriod
    {
        public bool Uke { get; set; } = false;
        public bool Måned { get; set; } = false;
        
        public void toggleUke(){
            this.Uke = !Uke;
            Console.WriteLine("Uke " + Uke);
        }
        public void toggleMåned(){
            this.Måned = !Måned;
            Console.WriteLine("Måned " + Måned);
        }
    }
}