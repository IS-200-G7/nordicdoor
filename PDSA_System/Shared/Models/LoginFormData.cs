namespace PDSA_System.Shared.Models;

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
