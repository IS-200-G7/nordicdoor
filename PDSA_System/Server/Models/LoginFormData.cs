namespace PDSA_System.Server.Models;

public class LoginFormData
{
    public string Brukernavn { get; set; }
    public string Passord { get; set; }

    public LoginFormData(string brukernavn, string passord)
    {
        this.Brukernavn = brukernavn;
        this.Passord = passord;
    }
}
