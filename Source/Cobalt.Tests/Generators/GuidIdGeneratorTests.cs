using Cobalt.Generators;
using System;
using Xunit;

namespace Cobalt.Tests.Generators
{
    public class GuidIdGeneratorTests
    {
        [Fact]
        public void GetCurrentId_ReturnsEmpty_WhenNextNeverCalled()
        {
            var idGenerator = IdGeneratorFactory.GetGuidIdGenerator();

            var sut = idGenerator.GetCurrentId();

            Assert.Equal(Guid.Empty, sut);
        }

        [Fact]
        public void GetCurrentId_ReturnsSameAsPrevious()
        {
            var idGenerator = IdGeneratorFactory.GetGuidIdGenerator();

            var id = idGenerator.GetNextId();
            var sut = idGenerator.GetCurrentId();

            Assert.Equal(id, sut);
        }

        [Fact]
        public void GetNextId_ReturnsNewValue()
        {
            var idGenerator = IdGeneratorFactory.GetGuidIdGenerator();

            var sutA = idGenerator.GetNextId();
            var sutB = idGenerator.GetNextId();

            Assert.NotEqual(sutA, sutB);
            Assert.NotEqual(Guid.Empty, sutA);
            Assert.NotEqual(Guid.Empty, sutB);
        }

        [Fact]
        public void GetNumberOfIdsGenerated_ReturnsCorrectValue()
        {
            var idGenerator = IdGeneratorFactory.GetGuidIdGenerator();

            idGenerator.GetNextId();
            idGenerator.GetNextId();
            idGenerator.GetCurrentId();
            idGenerator.GetNextId();

            var sut = idGenerator.GetNumberOfIdsGenerated();

            Assert.Equal(3, sut);
        }

    }
}
