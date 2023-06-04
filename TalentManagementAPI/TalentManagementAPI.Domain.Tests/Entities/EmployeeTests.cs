namespace TalentManagementAPI.Domain.Tests.Entities
{
    using AutoFixture;
    using Moq.AutoMock;
    using System;
    using TalentManagementAPI.Domain.Entities;
    using TalentManagementAPI.Domain.Enums;
    using Xunit;

    public class EmployeeTests
    {
        private Employee _testClass;

        public EmployeeTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<Employee>();
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

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetEmployeeTitle()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.EmployeeTitle = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeTitle);
        }

        [Fact]
        public void CanSetAndGetDOB()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<DateTime>();

            // Act
            _testClass.DOB = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DOB);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<Gender>();

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }

        [Fact]
        public void CanSetAndGetEmployeeNumber()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.EmployeeNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeNumber);
        }

        [Fact]
        public void CanSetAndGetSuffix()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Suffix = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Suffix);
        }

        [Fact]
        public void CanSetAndGetPhone()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Phone = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Phone);
        }
    }
}