namespace PDSA_System.Test;

public class JwtClaimsTest
{
    [TestCase("test@nordic.door", "Fornavn", "Navnesen", "ansatt", "1")]
    [TestCase("test2@nordic.door", "Navn", "Etternavnesen", "admin", "10")]
    public void TestPasswordHash(string epost, string fornavn, string etternavn, string rolle, string ansattNr)
    {
        JwtClaims claims = new JwtClaims(epost, fornavn, etternavn, rolle, ansattNr, "ft2NueB9H8N9p8RpVvWfwW_CHANGE_ME");

        var token = claims.GenerateToken();
        var newClaims = JwtClaims.GetClaims(token);

        Assert.Multiple(() =>
        {
            Assert.That(newClaims.Epost, Is.EqualTo(epost));
            Assert.That(newClaims.Fornavn, Is.EqualTo(fornavn));
            Assert.That(newClaims.Etternavn, Is.EqualTo(etternavn));
            Assert.That(newClaims.Rolle, Is.EqualTo(rolle));
            Assert.That(newClaims.AnsattNr, Is.EqualTo(ansattNr));
        });
    }
}
