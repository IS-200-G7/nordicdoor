namespace PDSA_System.Test;

public class PassordHashTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Pass", "C7zEnhyOfa7TDzz8IzVd9o4MVvGyuL0qWE/zCJzaocI=")]
    [TestCase("password", "nmK98RKKrQmMbV1mMwAA78hLSzwQ8PhxkQOdkvBa5IU=")]
    [TestCase("rockyou123", "+0Uk1K/PfuYf0ZYuvZpYHuFPoMgCMYntdAF/KwyVDDg=")]
    public void TestPasswordHash(string password, string expectedHash)
    {
        var hasher = new PasswordHash();

        // Null-salt for simplicity
        byte[] salt = Convert.FromBase64String("A000000000000000000000000000000000000000000=");
        var hash = hasher.HashPassword(password, salt);

        var hashBase64 = Convert.ToBase64String(hash);

        Assert.That(expectedHash, Is.EqualTo(hashBase64));
    }
}
