namespace PDSA_System.Server;

public class JwtSettings
{
    public string SecretKey { get; set; }
    //public string Issuer { get; set; }
    //public string Audience { get; set; }

    public JwtSettings(string secretKey)
    {
        SecretKey = secretKey;
    }
}
