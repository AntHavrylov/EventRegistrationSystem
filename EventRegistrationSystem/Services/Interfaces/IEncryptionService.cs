namespace EventRegistrationSystem.Services.Interfaces;

public interface IEncryptionService
{
    public string HashPassword(string data, out string salt);
    public bool VerifyPassword(string data, string encryptedData, string salt);
}

