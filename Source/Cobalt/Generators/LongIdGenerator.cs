namespace Cobalt.Generators
{
    public class LongIdGenerator : IIdGenerator<long>
    {
        private long Id;
        private long StartId;

        public LongIdGenerator(long startId = 0)
        {
            Id = startId;
            StartId = startId;
        }

        public long GetCurrentId() => Id;
        public long GetNextId() => ++Id;
        public int GetNumberOfIdsGenerated() => (int)(Id - StartId);
    }
}
