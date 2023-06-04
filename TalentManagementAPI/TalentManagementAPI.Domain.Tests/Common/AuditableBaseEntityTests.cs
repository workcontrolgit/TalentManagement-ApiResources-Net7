namespace TalentManagementAPI.Domain.Tests.Common
{
    using AutoFixture;
    using Moq.AutoMock;
    using System;
    using TalentManagementAPI.Domain.Common;
    using Xunit;

    public class AuditableBaseEntityTests
    {
        private class TestAuditableBaseEntity : AuditableBaseEntity
        {
        }

        private TestAuditableBaseEntity _testClass;

        public AuditableBaseEntityTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<TestAuditableBaseEntity>();
        }

        [Fact]
        public void CanSetAndGetCreatedBy()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.CreatedBy = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CreatedBy);
        }

        [Fact]
        public void CanSetAndGetCreated()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<DateTime>();

            // Act
            _testClass.Created = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Created);
        }

        [Fact]
        public void CanSetAndGetLastModifiedBy()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.LastModifiedBy = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastModifiedBy);
        }

        [Fact]
        public void CanSetAndGetLastModified()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<DateTime?>();

            // Act
            _testClass.LastModified = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastModified);
        }
    }
}