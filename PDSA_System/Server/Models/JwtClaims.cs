using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PDSA_System.Server.Models;

public class JwtClaims
{
    private string Epost { get; set; }
    private string Fornavn { get; set; }
    private string Etternavn { get; set; }
    private string Rolle { get; set; } // Admin, bruker, etc.
    private string AnsattNr { get; set; }
    private string Secret { get; set; }

    public JwtClaims(string epost, string fornavn, string etternavn, string rolle, string ansattNr, string jwtSecret)
    {
        this.Epost = epost;
        this.Fornavn = fornavn;
        this.Etternavn = etternavn;
        this.Rolle = rolle;
        this.AnsattNr = ansattNr;
        this.Secret = jwtSecret;
    }

    // Generer en JWT token
    public string GenerateToken()
    {
        var claims = new[] // Bruker standardiserte navn på claims
        {
            new Claim("fornavn", Fornavn),
            new Claim("etternavn", Etternavn),
            new Claim("epost", Epost),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, Rolle), 
            new Claim("brukerId", AnsattNr)
    
        };

        // Hente og generere nøkler for autentisering
        // Key er hardcoded kun for utvikling. Denne MÅ endres til å hente fra appsettings.json
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret ?? "ft2NueB9H8N9p8RpVvWfwWPstApP6gus"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Generer token, issuer og audience kan vi vente med til senere
        var token = new JwtSecurityToken(
            //issuer: "http://localhost:5000",
            //audience: "http://localhost:5000",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // Hente claims fra en JWT token
    public static JwtClaims GetClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token);
        var tokenS = jsonToken as JwtSecurityToken;

        if (tokenS == null)
        {
            return new JwtClaims("", "", "", "", "", null);
        }

        var epost = tokenS.Claims.First(claim => claim.Type == "epost").Value;
        var fornavn = tokenS.Claims.First(claim => claim.Type == "fornavn").Value;
        var etternavn = tokenS.Claims.First(claim => claim.Type == "etternavn").Value;
        var rolle = tokenS.Claims.First(claim => claim.Type == "rolle").Value;
        var ansattNr = tokenS.Claims.First(claim => claim.Type == "brukerId").Value;

        return new JwtClaims(epost, fornavn, etternavn, rolle, ansattNr, null);
    }
}
