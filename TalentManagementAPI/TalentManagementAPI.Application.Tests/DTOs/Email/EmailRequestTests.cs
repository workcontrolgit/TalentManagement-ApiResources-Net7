namespace TalentManagementAPI.Application.Tests.DTOs.Email
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.DTOs.Email;
    using Xunit;

    public class EmailRequestTests
    {
        private EmailRequest _testClass;

        public EmailRequestTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<EmailRequest>();
        }

        [Fact]
        public void CanSetAndGetTo()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.To = testValue;

            // Assert
            _testClass.To.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetSubject()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Subject = testValue;

            // Assert
            _testClass.Subject.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetBody()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Body = testValue;

            // Assert
            _testClass.Body.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetFrom()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.From = testValue;

            // Assert
            _testClass.From.Should().Be(testValue);
        }
    }
}