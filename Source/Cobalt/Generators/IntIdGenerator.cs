namespace Cobalt.Generators
{
    public class IntIdGenerator : IIdGenerator<int>
    {
        private int Id;
        private readonly int StartId;

        public IntIdGenerator(int startId = 0)
        {
            Id = startId;
            StartId = startId;
        }

        public int GetCurrentId() => Id;
        public int GetNextId() => ++Id;
        public int GetNumberOfIdsGenerated() => Id - StartId;
    }
}
