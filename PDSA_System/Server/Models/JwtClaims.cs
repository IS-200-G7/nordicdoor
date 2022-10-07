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

    private string BrukerId { get; set; }
    private int Exp { get; set; }

    public JwtClaims(string epost, string fornavn, string etternavn, string rolle, string brukerId)
    {
        this.Epost = epost;
        this.Fornavn = fornavn;
        this.Etternavn = etternavn;
        this.Rolle = rolle;
        this.BrukerId = brukerId;
        //this.Exp = exp;
    }

    // Generer en JWT token
    public string GenerateToken()
    {
        var claims = new[] // Bruker standardiserte navn på claims
        {
            new Claim(JwtRegisteredClaimNames.GivenName, Fornavn),
            new Claim(JwtRegisteredClaimNames.FamilyName, Etternavn),
            new Claim(JwtRegisteredClaimNames.Email, Epost),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", Rolle),
            new Claim("userId", BrukerId)
        };

        // Hente og generere nøkler for autentisering
        // Key er hardcoded kun for utvikling. Denne MÅ endres til å hente fra appsettings.json
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("ED02457B5C41D964DBD2F2A609D63FE1BB7528DBE55E1ABF5B52C249CD735797"));
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

        var epost = tokenS.Claims.First(claim => claim.Type == "email").Value;
        var fornavn = tokenS.Claims.First(claim => claim.Type == "given_name").Value;
        var etternavn = tokenS.Claims.First(claim => claim.Type == "family_name").Value;
        var rolle = tokenS.Claims.First(claim => claim.Type == "role").Value;
        var brukerId = tokenS.Claims.First(claim => claim.Type == "userId").Value;

        // Exp er ikke nødvendig å hente ut, da den ikke brukes i applikasjonen, bør implementeres senere
        //var exp = tokenS.Claims.First(claim => claim.Type == "exp").Value;

        return new JwtClaims(epost, fornavn, etternavn, rolle, brukerId);
    }
}
