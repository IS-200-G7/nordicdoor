using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace PDSA_System.Server;

public class PasswordHash
{
    // Generere 32 tilfeldige bytes
    public byte[] CreateSalt()
    {
        var buffer = new byte[32];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);
        return buffer;
    }

    // Generere hash fra passord og salt
    public byte[] HashPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // four cores
        argon2.Iterations = 6;
        argon2.MemorySize = 256 * 1024; // 1 GB

        return argon2.GetBytes(32);
    }

    // Verifisere et hash mot et passord og salt
    public bool Verify(string password, byte[] salt, byte[] hash)
    {
        return HashPassword(password, salt).SequenceEqual(hash);
    }
}
