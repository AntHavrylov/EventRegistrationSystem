using EventRegistrationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace EventRegistrationSystem.Services;

public class EncryptionService : IEncryptionService
{
    public string HashPassword(string password, out string salt)
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        salt = Convert.ToBase64String(saltBytes);

        string hashedData = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32));

        return hashedData;
    }

    public bool VerifyPassword(string password, string encryptedData, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        string hashedDataCandidate = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32));
        return encryptedData == hashedDataCandidate;
    }
}
