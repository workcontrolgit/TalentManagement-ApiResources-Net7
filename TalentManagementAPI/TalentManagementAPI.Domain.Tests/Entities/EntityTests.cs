namespace TalentManagementAPI.Domain.Tests.Entities
{
    using AutoFixture;
    using Moq.AutoMock;
    using System;
    using System.Collections.Generic;
    using TalentManagementAPI.Domain.Entities;
    using Xunit;

    public class EntityTests
    {
        private Entity _testClass;

        public EntityTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<Entity>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Entity();

            // Assert
            Assert.NotNull(instance);
        }


        [Fact]
        public void CannotCallCopyToWithNullArray()
        {
            // Arrange
            var fixture = new Fixture();
            Assert.Throws<ArgumentNullException>(() => _testClass.CopyTo(default(KeyValuePair<string, object>[]), fixture.Create<int>()));
        }

    }
}