using System;

namespace Cobalt.Generators
{
    public static class IdGeneratorFactory
    {
        public static IIdGenerator<Guid> GetGuidIdGenerator()
        {
            return new GuidIdGenerator();
        }

        public static IIdGenerator<int> GetIntIdGenerator(int startId = 0)
        {
            return new IntIdGenerator(startId);
        }

        public static IIdGenerator<long> GetLongIdGenerator(int startId = 0)
        {
            return new LongIdGenerator(startId);
        }
    }
}
