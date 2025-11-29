using EventRegistrationSystem.Services;
using EventRegistrationSystem.Services.Interfaces;
using Xunit;

namespace EventRegistrationSystem.Tests.Unit.Services
{
    public class EncryptionServiceTests
    {
        private readonly IEncryptionService _sut;

        public EncryptionServiceTests()
        {
            _sut = new EncryptionService();
        }


        [Theory]
        [InlineData("test123")]
        public void HashPassword_ShouldReturn_NonEmptyHashAndSalt(string password)
        {            
            var hash = _sut.HashPassword(password, out string salt);

            Assert.False(string.IsNullOrEmpty(hash));
            Assert.False(string.IsNullOrEmpty(salt));
        }

        [Theory]
        [InlineData("password123")]
        [InlineData("helloWorld")]
        [InlineData("testPass!")]
        [InlineData("aBuraKa@#$!~dabur23@#!!")]
        public void HashAndVerifyPassword_ShouldHashAndVerifyPassword(string password)
        {
            string salt;
            var hashedPassword = _sut.HashPassword(password, out salt);

            Assert.False(string.IsNullOrEmpty(hashedPassword));
            Assert.False(string.IsNullOrEmpty(salt));

            bool isVerified = _sut.VerifyPassword(password, hashedPassword, salt);
            Assert.True(isVerified);

            bool isVerifiedWrong = _sut.VerifyPassword("wrong" + password, hashedPassword, salt);
            Assert.False(isVerifiedWrong);
        }
    }
}
