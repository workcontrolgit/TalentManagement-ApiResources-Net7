namespace TalentManagementAPI.Domain.Tests.Common
{
    using AutoFixture;
    using Moq.AutoMock;
    using System;
    using TalentManagementAPI.Domain.Common;
    using Xunit;

    public class BaseEntityTests
    {
        private class TestBaseEntity : BaseEntity
        {
        }

        private TestBaseEntity _testClass;

        public BaseEntityTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<TestBaseEntity>();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<Guid>();

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }
    }
}