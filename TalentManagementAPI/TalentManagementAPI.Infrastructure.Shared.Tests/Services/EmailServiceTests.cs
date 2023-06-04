namespace TalentManagementAPI.Infrastructure.Shared.Tests.Services
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using Moq.AutoMock;
    using TalentManagementAPI.Domain.Settings;
    using TalentManagementAPI.Infrastructure.Shared.Services;
    using Xunit;

    public class EmailServiceTests
    {
        private EmailService _testClass;
        private Mock<IOptions<MailSettings>> _mailSettings;
        private Mock<ILogger<EmailService>> _logger;

        public EmailServiceTests()
        {
            var mocker = new AutoMocker();
            _mailSettings = mocker.GetMock<IOptions<MailSettings>>();
            _logger = mocker.GetMock<ILogger<EmailService>>();
            _testClass = mocker.CreateInstance<EmailService>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmailService(_mailSettings.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

    }
}