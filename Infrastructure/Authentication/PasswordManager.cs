using System.Security.Cryptography;
using Application.Contracts.Authentication;

namespace Infrastructure.Authentication;

public class PasswordManager : IPasswordManager
{
    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

    public bool Verify(string providedPassword, string hashedPassword) => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

    public string GenerateRandomPassword()
    {
        byte[] randomBytes = new byte[8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        return Convert.ToBase64String(randomBytes);
    }
}