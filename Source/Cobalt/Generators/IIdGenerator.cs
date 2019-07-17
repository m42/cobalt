namespace Cobalt.Generators
{
    public interface IIdGenerator<T>
    {
        T GetCurrentId();
        T GetNextId();
        int GetNumberOfIdsGenerated();

    }
}
