using System;

namespace Cobalt.Generators
{
    public class GuidIdGenerator : IIdGenerator<Guid>
    {
        private int NumberOfIdsGenerated;
        private Guid CurrentId;

        public Guid GetCurrentId() => CurrentId;

        public Guid GetNextId()
        {
            NumberOfIdsGenerated++;
            CurrentId = Guid.NewGuid();
            return CurrentId;
        }

        public int GetNumberOfIdsGenerated() => NumberOfIdsGenerated;
    }
}
