﻿using Cobalt.Generators;
using Xunit;

namespace Cobalt.Tests.Generators
{
    public class IntIdGeneratorTests
    {
        [Fact]
        public void GetCurrentId_ReturnsSameAsPrevious()
        {
            var idGenerator = IdGeneratorFactory.GetIntIdGenerator(100);

            idGenerator.GetNextId();
            var sut = idGenerator.GetCurrentId();

            Assert.Equal(101, sut);
        }

        [Fact]
        public void GetNextId_ReturnsNewValue_WhenNoStartIdSupplied()
        {
            var idGenerator = IdGeneratorFactory.GetIntIdGenerator();

            var sutA = idGenerator.GetNextId();
            var sutB = idGenerator.GetNextId();
            var sutC = idGenerator.GetNextId();

            Assert.Equal(1, sutA);
            Assert.Equal(2, sutB);
            Assert.Equal(3, sutC);
        }

        [Fact]
        public void GetNextId_ReturnsNewValue_WhenStartIdSupplied()
        {
            var idGenerator = IdGeneratorFactory.GetIntIdGenerator(100);

            var sutA = idGenerator.GetNextId();
            var sutB = idGenerator.GetNextId();
            var sutC = idGenerator.GetNextId();

            Assert.Equal(101, sutA);
            Assert.Equal(102, sutB);
            Assert.Equal(103, sutC);
        }

        [Fact]
        public void GetNumberOfIdsGenerated_ReturnsCorrectValue()
        {
            var idGenerator = IdGeneratorFactory.GetIntIdGenerator();

            idGenerator.GetNextId();
            idGenerator.GetNextId();

            var sut = idGenerator.GetNumberOfIdsGenerated();

            Assert.Equal(2, sut);
        }

    }
}
