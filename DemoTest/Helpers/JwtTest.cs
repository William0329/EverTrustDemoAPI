using EverTrustDemoAPI.Helpers;

using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;

namespace DemoTest.Helpers
{
    [TestClass]
    public class JwtTest
    {
        private IConfiguration _configuration;
        private JwtHelper _jwtHelper;

        [TestInitialize]
        public void Setup()
        {
            // �ϥ� ConfigurationBuilder �c�� IConfiguration
            var inMemorySettings = new Dictionary<string, string>
            {
                {"JwtSettings:ExpireMinutes", "60"},
                {"JwtSettings:Issuer", "test_issuer"},
                {"JwtSettings:Key", Convert.ToBase64String(new byte[32])}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _jwtHelper = new JwtHelper(_configuration);
        }
        [TestMethod]
        public void Test()
        {
            // Arrange
            var userName = "testUser";
            var systems = new List<string> { "System1", "System2" };
            var userId = "12345";
            var companyId = "67890";

            // Act
            var token = _jwtHelper.GenerateToken(userName, systems, userId, companyId);

            // Assert
            Assert.IsNotNull(token, "Token should not be null");

            // ���� JWT ���e
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // �ˬd Claim �O�_�]�t���w����
            Assert.AreEqual("testUser", jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.UniqueName).Value);
            Assert.AreEqual("12345", jwtToken.Claims.First(c => c.Type == "UserId").Value);
            Assert.AreEqual("67890", jwtToken.Claims.First(c => c.Type == "CompanyId").Value);

            // ���� "Systems" claim �O�_�]�t���檺 JSON �r��
            var systemsClaim = jwtToken.Claims.First(c => c.Type == "Systems").Value;
            Assert.AreEqual("[\"System1\",\"System2\"]", systemsClaim);

            // ���� Token ����L�ݩʡA�p�o��̡B�L���ɶ�
            Assert.AreEqual("test_issuer", jwtToken.Issuer);
            Assert.IsTrue(jwtToken.ValidTo > DateTime.UtcNow.AddMinutes(59)); // �ˬd�O�_���T�]�w�L���ɶ�
        }
    }
}