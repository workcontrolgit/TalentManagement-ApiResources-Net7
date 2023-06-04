namespace TalentManagementAPI.Domain.Tests.Settings
{
    using AutoFixture;
    using Moq.AutoMock;
    using TalentManagementAPI.Domain.Settings;
    using Xunit;

    public class MailSettingsTests
    {
        private MailSettings _testClass;

        public MailSettingsTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<MailSettings>();
        }

        [Fact]
        public void CanSetAndGetEmailFrom()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.EmailFrom = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailFrom);
        }

        [Fact]
        public void CanSetAndGetSmtpHost()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.SmtpHost = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SmtpHost);
        }

        [Fact]
        public void CanSetAndGetSmtpPort()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<int>();

            // Act
            _testClass.SmtpPort = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SmtpPort);
        }

        [Fact]
        public void CanSetAndGetSmtpUser()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.SmtpUser = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SmtpUser);
        }

        [Fact]
        public void CanSetAndGetSmtpPass()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.SmtpPass = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SmtpPass);
        }

        [Fact]
        public void CanSetAndGetDisplayName()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.DisplayName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DisplayName);
        }
    }
}