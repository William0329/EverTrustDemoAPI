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
            // 使用 ConfigurationBuilder 構建 IConfiguration
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

            // 驗證 JWT 內容
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // 檢查 Claim 是否包含指定的值
            Assert.AreEqual("testUser", jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.UniqueName).Value);
            Assert.AreEqual("12345", jwtToken.Claims.First(c => c.Type == "UserId").Value);
            Assert.AreEqual("67890", jwtToken.Claims.First(c => c.Type == "CompanyId").Value);

            // 驗證 "Systems" claim 是否包含期望的 JSON 字串
            var systemsClaim = jwtToken.Claims.First(c => c.Type == "Systems").Value;
            Assert.AreEqual("[\"System1\",\"System2\"]", systemsClaim);

            // 驗證 Token 的其他屬性，如發行者、過期時間
            Assert.AreEqual("test_issuer", jwtToken.Issuer);
            Assert.IsTrue(jwtToken.ValidTo > DateTime.UtcNow.AddMinutes(59)); // 檢查是否正確設定過期時間
        }
    }
}